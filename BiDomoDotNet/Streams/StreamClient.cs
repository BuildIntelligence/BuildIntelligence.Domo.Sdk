using BiDomoDotNet.Datasets;
using BiDomoDotNet.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BiDomoDotNet.Streams
{
	public class StreamClient : IDomoStreamClient
	{
		private DomoHttpClient _domoHttpClient;

		public StreamClient(IDomoConfig config)
		{
			_domoHttpClient = new DomoHttpClient(config);
		}

		/// <summary>
		/// Create a stream dataset
		/// </summary>
		/// <param name="datasetSchema">Schema and metadata for the dataset to create</param>
		/// <param name="updateMethod">Update method type for stream dataset. Options are Append or Replace</param>
		/// <returns></returns>
		public async Task<StreamDataset> CreateAsync(IDatasetSchema datasetSchema, UpdateMethod updateMethod)
		{
			string streamUri = "v1/streams";

			//_domoHttpClient.SetContentType("application/json");
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			string dsUpdateMethod = "";
			if (updateMethod == UpdateMethod.APPEND)
			{
				dsUpdateMethod = "APPEND";
			}
			else if (updateMethod == UpdateMethod.REPLACE)
			{
				dsUpdateMethod = "REPLACE";
			}
			var streamSchema = new StreamDatasetSchema() { DataSet = datasetSchema, UpdateMethod = dsUpdateMethod };
			string schemaJson = JsonConvert.SerializeObject(streamSchema, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
			StringContent content = new StringContent(schemaJson, Encoding.UTF8, "application/json");

			var response = await _domoHttpClient.Client.PostAsync(streamUri, content);
			string responseMessage = await response.Content.ReadAsStringAsync();
			var newStreamDataset = JsonConvert.DeserializeObject<StreamDataset>(responseMessage);

			return newStreamDataset;
		}

		/// <summary>
		/// Get details for a given Stream Dataset
		/// </summary>
		/// <param name="streamId">Stream to get details of</param>
		/// <returns></returns>
		public async Task<StreamDataset> GetStreamDetailsAsync(int streamId)
		{
			string streamUri = $"v1/streams/{streamId}";
            
			var response = await _domoHttpClient.Client.GetAsync(streamUri);
			string responseMessage = await response.Content.ReadAsStringAsync();
			var streamDataset = JsonConvert.DeserializeObject<StreamDataset>(responseMessage);

			return streamDataset;
		}

		/// <summary>
		/// Get a list of Stream datasets
		/// </summary>
		/// <param name="limit">number of stream datasets to return. Maximum 500.</param>
		/// <param name="offset">Offset to start the list from</param>
		/// <returns></returns>
		public async Task<List<StreamDataset>> ListAsync(int limit, int offset)
		{
            if (limit > 500) throw new LimitNotWithinBoundsException($"The list limit of {limit} used is above the max limit. The maximum limit is 500");
            if (limit < 0) throw new LimitNotWithinBoundsException($"List limit {limit} cannot be used. Use a limit value between 1 and 500");

			string streamsUri = $"v1/streams?limit={limit}&offset={offset}";

			var response = await _domoHttpClient.Client.GetAsync(streamsUri);
			string responseMessage = await response.Content.ReadAsStringAsync();
			var streamsDatasets = JsonConvert.DeserializeObject<List<StreamDataset>>(responseMessage);

			return streamsDatasets;
		}

		/// <summary>
		/// Update Dataset Metadata for a given stream. This might be dataset name/description changes and/or dataset schema changes.
		/// </summary>
		/// <param name="streamId">Stream Id to Update metadata</param>
		/// <param name="streamDataset">New metadata to change the Stream to</param>
		/// <returns></returns>
		public async Task<StreamDataset> UpdateMetaAsync(int streamId, StreamDataset streamDataset)
		{
			string streamUri = $"v1/streams/{streamId}";

			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			string schemaJson = JsonConvert.SerializeObject(streamDataset, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
			StringContent content = new StringContent(schemaJson, Encoding.UTF8, "application/json");

			var response = await _domoHttpClient.Client.PutAsync(streamUri, content);
			string responseMessage = await response.Content.ReadAsStringAsync();
			var newStreamDatasetMeta = JsonConvert.DeserializeObject<StreamDataset>(responseMessage);

			return newStreamDatasetMeta;
		}

		/// <summary>
		/// Deletes a Stream from a Domo instance. This doesn't delete the associated DataSet
		/// </summary>
		/// <param name="streamId">Id for Stream to Delete</param>
		/// <returns>Returns HttpResponseMessage. For Success/Failure check the isSuccessStatusCode prop</returns>
		public async Task<HttpResponseMessage> DeleteAsync(int streamId)
		{
			string streamUri = $"v1/streams/{streamId}";

			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.DeleteAsync(streamUri);

			return response;
		}



		/// <summary>
		/// Creats an execution stream for a given Stream to upload data parts to
		/// </summary>
		/// <param name="streamId">Stream Id to Create execution for</param>
		/// <returns></returns>
		public async Task<StreamExecution> CreateStreamExecutionAsync(long streamId)
		{
			string relativeStreamUri = $"v1/streams/{streamId}/executions";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			var response = await _domoHttpClient.Client.PostAsync(relativeStreamUri, new StringContent("", Encoding.UTF8, "application/json"));
			string responseMessage = await response.Content.ReadAsStringAsync();
			var newStreamExecution = JsonConvert.DeserializeObject<StreamExecution>(responseMessage);

			return newStreamExecution;
		}

		/// <summary>
		/// List Executions for a given Stream
		/// </summary>
		/// <param name="streamId">Id of Stream to get list of executions for</param>
		/// <param name="limit">amount of executions to return in the list. Maximum is 500</param>
		/// <param name="offset">The offset of the Execution ID to begin list from</param>
		/// <returns></returns>
		public async Task<List<StreamExecution>> ListStreamExecutionsAsync(long streamId, int limit, int offset)
		{
			string streamExecutionsUri = $"v1/streams/{streamId}/executions?limit={limit}&offset={offset}";

			var response = await _domoHttpClient.Client.GetAsync(streamExecutionsUri);
			string responseMessage = await response.Content.ReadAsStringAsync();
			var streamExecutions = JsonConvert.DeserializeObject<List<StreamExecution>>(responseMessage);

			return streamExecutions;
		}

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
		public async Task<HttpResponseMessage> UploadDataPartAsync(int streamId, int streamExecutionId, int partNumber, string csvContent)
		{
			string relStreamExecUri = $"v1/streams/{streamId}/executions/{streamExecutionId}/part/{partNumber}";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");

			var response = await _domoHttpClient.Client.PutAsync(relStreamExecUri, new StringContent(csvContent, Encoding.UTF8, "text/csv"));

			return response;
		}

		/// <summary>
		/// Commits a given execution for a stream. Can Only execute a commit every 15 minutes.
		/// </summary>
		/// <param name="streamId">Stream Id</param>
		/// <param name="executionId">Execution Id to Commit</param>
		/// <returns></returns>
		public async Task<StreamExecution> CommitExecutionAsync(int streamId, int executionId)
		{
			string relStreamExecUri = $"v1/streams/{streamId}/executions/{executionId}/commit";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			var response = await _domoHttpClient.Client.PutAsync(relStreamExecUri, new StringContent("", Encoding.UTF8, "application/json"));
			string resMsg = await response.Content.ReadAsStringAsync();
			var streamExecution = JsonConvert.DeserializeObject<StreamExecution>(resMsg);

			return streamExecution;
		}

		/// <summary>
		/// Aborts entire stream execution
		/// </summary>
		/// <param name="streamId">Id of Stream</param>
		/// <param name="executionId">Id of execution to abort</param>
		/// <returns>successfully aborted</returns>
		public async Task<bool> AbortStreamExecutionAsync(int streamId, int executionId)
		{
			string relStreamExecUri = $"v1/streams/{streamId}/executions/{executionId}/abort";
			_domoHttpClient.SetAcceptRequestHeaders("application/json");
			var res = await _domoHttpClient.Client.PutAsync(relStreamExecUri, new StringContent("", Encoding.UTF8, "application/json"));

			return res.IsSuccessStatusCode;
		}
	}

}
