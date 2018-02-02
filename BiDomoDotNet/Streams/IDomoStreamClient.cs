using BiDomoDotNet.Datasets;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiDomoDotNet.Streams
{
    public interface IDomoStreamClient
    {
        Task<StreamDataset> CreateAsync(IDatasetSchema datasetSchema, UpdateMethod updateMethod);
        Task<StreamDataset> GetStreamDetailsAsync(int streamId);
        Task<List<StreamDataset>> ListAsync(int limit, int offset);
        Task<StreamDataset> UpdateMetaAsync(int streamId, StreamDataset streamDataset);
        Task<HttpResponseMessage> DeleteAsync(int streamId);
        Task<StreamExecution> CreateStreamExecutionAsync(long streamId);
        Task<List<StreamExecution>> ListStreamExecutionsAsync(long streamId, int limit, int offset);
        Task<HttpResponseMessage> UploadDataPartAsync(int streamId, int streamExecutionId, int partNumber, string csvContent);
        Task<StreamExecution> CommitExecutionAsync(int streamId, int executionId);
        Task<bool> AbortStreamExecutionAsync(int streamId, int executionId);
    }
}
