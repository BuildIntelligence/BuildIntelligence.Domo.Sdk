using BiDomoDotNet.Datasets;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiDomoDotNet.Streams
{
    public interface IDomoStreamClient
    {
        /// <summary>
		/// Create a stream dataset
		/// </summary>
		/// <param name="datasetSchema">Schema and metadata for the dataset to create</param>
		/// <param name="updateMethod">Update method type for stream dataset. Options are Append or Replace</param>
		/// <returns></returns>
        Task<StreamDataset> CreateAsync(IDatasetSchema datasetSchema, UpdateMethod updateMethod);

        /// <summary>
		/// Get details for a given Stream Dataset
		/// </summary>
		/// <param name="streamId">Stream to get details of</param>
		/// <returns></returns>
        Task<StreamDataset> GetStreamDetailsAsync(int streamId);

        /// <summary>
		/// Get a list of Stream datasets
		/// </summary>
		/// <param name="limit">number of stream datasets to return. Maximum 500.</param>
		/// <param name="offset">Offset to start the list from</param>
		/// <returns></returns>
        Task<List<StreamDataset>> ListAsync(int limit, int offset);

        /// <summary>
		/// Update Dataset Metadata for a given stream. This might be dataset name/description changes and/or dataset schema changes.
		/// </summary>
		/// <param name="streamId">Stream Id to Update metadata</param>
		/// <param name="streamDataset">New metadata to change the Stream to</param>
		/// <returns></returns>
        Task<StreamDataset> UpdateMetaAsync(int streamId, StreamDataset streamDataset);

        /// <summary>
		/// Deletes a Stream from a Domo instance. This doesn't delete the associated DataSet
		/// </summary>
		/// <param name="streamId">Id for Stream to Delete</param>
		/// <returns>Returns HttpResponseMessage. For Success/Failure check the isSuccessStatusCode prop</returns>
        Task<HttpResponseMessage> DeleteAsync(int streamId);

        /// <summary>
		/// Creats an execution stream for a given Stream to upload data parts to
		/// </summary>
		/// <param name="streamId">Stream Id to Create execution for</param>
		/// <returns></returns>
        Task<StreamExecution> CreateStreamExecutionAsync(long streamId);

        /// <summary>
		/// List Executions for a given Stream
		/// </summary>
		/// <param name="streamId">Id of Stream to get list of executions for</param>
		/// <param name="limit">amount of executions to return in the list. Maximum is 500</param>
		/// <param name="offset">The offset of the Execution ID to begin list from</param>
		/// <returns></returns>
        Task<List<StreamExecution>> ListStreamExecutionsAsync(long streamId, int limit, int offset);

        /// <summary>
		/// Add Data Part for Execution Stream. Can be done in parallel. 
		/// For narrow tables (i.e. less than 100 columns wide) 10k to 100k is probably the best chunk size
		/// </summary>
		/// <param name="streamId">Stream Id</param>
		/// <param name="streamExecutionId">Execution Id to Upload part to</param>
		/// <param name="partNumber">Part number for data chunk to upload</param>
		/// <param name="csvContent">Csv data chunk to upload</param>
		/// <returns>HttpResponseMessage for Data part upload</returns>
		/// TODO: gzip
        Task<HttpResponseMessage> UploadDataPartAsync(int streamId, int streamExecutionId, int partNumber, string csvContent);

        /// <summary>
		/// Commits a given execution for a stream. Can Only execute a commit every 15 minutes.
		/// </summary>
		/// <param name="streamId">Stream Id</param>
		/// <param name="executionId">Execution Id to Commit</param>
		/// <returns></returns>
        Task<StreamExecution> CommitExecutionAsync(int streamId, int executionId);

        /// <summary>
		/// Aborts entire stream execution
		/// </summary>
		/// <param name="streamId">Id of Stream</param>
		/// <param name="executionId">Id of execution to abort</param>
		/// <returns>successfully aborted</returns>
        Task<bool> AbortStreamExecutionAsync(int streamId, int executionId);
    }
}
