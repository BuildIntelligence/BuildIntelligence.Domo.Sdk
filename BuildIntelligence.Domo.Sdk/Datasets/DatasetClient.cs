using BuildIntelligence.Domo.Sdk.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuildIntelligence.Domo.Sdk.Datasets
{
    public class DatasetClient : IDomoDatasetClient
    {
        // This class does not currently support PDP operations.

        private DomoHttpClient _domoHttpClient;

        public DatasetClient(IDomoConfig config)
        {
            _domoHttpClient = new DomoHttpClient(config);
        }

        /// <summary>
        /// Returns a list of datasets in Domo. Max list size is 50
        /// </summary>
        /// <param name="limit">Number of datasets to return. Max is 50</param>
        /// <param name="offset">Offset number of datasets to start return from</param>
        /// <returns></returns>
		public async Task<IEnumerable<Dataset>> ListDatasetsAsync(int limit, int offset /*Sorting as optional param or overload*/)
        {
            if (limit > 50) throw new LimitNotWithinBoundsException($"The list limit of {limit} used is above the max limit. The maximum limit is 50");
            if (limit < 0) throw new LimitNotWithinBoundsException($"List limit {limit} cannot be used. Use a limit value between 1 and 50");

            _domoHttpClient.SetAcceptRequestHeaders("application/json");

            var response = await _domoHttpClient.Client.GetAsync($"v1/datasets?limit={limit}&offset={offset}");
            string responseAsString = await response.Content.ReadAsStringAsync();
            var desResponse = JsonConvert.DeserializeObject<IEnumerable<Dataset>>(responseAsString);

            return desResponse;
        }

        /// <summary>
        /// Creates a dataset in DOMO with the specified schema. Does not populate dataset with data.
        /// </summary>
        /// <param name="schema"></param>
        /// <returns>Dataset object with newly created dataset information</returns>
        public async Task<Dataset> CreateDatasetAsync(IDatasetSchema schema)
        {
            string datasetUri = "v1/datasets";
            _domoHttpClient.SetAcceptRequestHeaders("application/json");
            string schemaJson = JsonConvert.SerializeObject(schema);
            StringContent content = new StringContent(schemaJson, Encoding.UTF8, "application/json");
            var response = await _domoHttpClient.Client.PostAsync(datasetUri, content);

            string responseMessage = await response.Content.ReadAsStringAsync();
            var newDataset = JsonConvert.DeserializeObject<Dataset>(responseMessage);

            return newDataset;
        }

        /// <summary>
        /// Updates existing dataset schema
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="schema"></param>
        /// <returns></returns>
        public async Task<Dataset> UpdateDatasetMetadataAsync(string datasetId, IDatasetSchema schema)
        {
            string datasetUri = $"v1/datasets/{datasetId}";
            _domoHttpClient.SetAcceptRequestHeaders("application/json");
            string schemaJson = JsonConvert.SerializeObject(schema);
            StringContent content = new StringContent(schemaJson, Encoding.UTF8, "application/json");
            var response = await _domoHttpClient.Client.PostAsync(datasetUri, content);

            string responseMessage = await response.Content.ReadAsStringAsync();
            var newDataset = JsonConvert.DeserializeObject<Dataset>(responseMessage);

            return newDataset;
        }

        /// <summary>
        /// Deletes a dataset
        /// </summary>
        /// <param name="datasetId"></param>
        /// <returns>Http Response from Delete Request</returns>
        public async Task<HttpResponseMessage> DeleteDatasetAsync(string datasetId)
        {
            string datasetUri = $"v1/datasets/{datasetId}";
            var response = await _domoHttpClient.Client.DeleteAsync($"{datasetUri}");
            return response;
        }

        /// <summary>
        /// Gets dataset as string in csv format
        /// </summary>
        /// <param name="datasetId"></param>
        /// <returns>Csv as string</returns>
        public async Task<string> RetrieveCsvAsync(string datasetId, bool includeHeader = false)
        {
            string datasetUri = $"v1/datasets/{datasetId}/data";
            _domoHttpClient.SetAcceptRequestHeaders("text/csv");
            var response = await _domoHttpClient.Client.GetAsync(datasetUri);
            string responseAsString = await response.Content.ReadAsStringAsync();
            return responseAsString;
        }


        /// <summary>
        /// Gets a dataset from Domo and saves a csv to the specified path on local computer
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="path"></param>
        /// <param name="includeHeader"></param>
        /// <param name="fileName">Including file extension</param>
        /// <returns>Boolean whether file was saved successfully</returns>
        public async Task ExportToCsvFile(string datasetId, string path, bool includeHeader, string fileName)
        {
            string datasetUri = $"v1/datasets/{datasetId}/data?includeHeader={includeHeader}&fileName={fileName}";
            _domoHttpClient.SetAcceptRequestHeaders("text/csv");
            var response = await _domoHttpClient.Client.GetAsync(datasetUri);
            string responseAsString = await response.Content.ReadAsStringAsync();
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fullPath = System.IO.Path.Combine(path, fileName);
            System.IO.File.WriteAllText(fullPath, responseAsString);
        }

        /// <summary>
        /// Gets metadata of dataset
        /// </summary>
        /// <param name="datasetId"></param>
        /// <returns></returns>
        public async Task<Dataset> RetrieveDatasetAsync(string datasetId)
        {
            string datasetAddress = $"v1/datasets/{datasetId}";
            _domoHttpClient.SetAcceptRequestHeaders("application/json");

            var response = await _domoHttpClient.Client.GetAsync(datasetAddress);
            string responseAsString = await response.Content.ReadAsStringAsync();
            Dataset responseMetadata = JsonConvert.DeserializeObject<Dataset>(responseAsString);
            return responseMetadata;
        }

        /// <summary>
        /// Updates the dataset schema
        /// </summary>
        /// <param name="datasetId"></param>
        /// <param name="datasetSchema"></param>
        /// <returns>Http Response from Dataset Metadata request</returns>
        public async Task<HttpResponseMessage> UpdateDatasetMetadataAsync(string datasetId, Dataset datasetSchema)
        {
            string datasetUri = $"v1/datasets/{datasetId}";
            _domoHttpClient.SetAcceptRequestHeaders("application/json");
            string schemaAsString = JsonConvert.SerializeObject(datasetSchema);
            StringContent content = new StringContent(schemaAsString, Encoding.UTF8, "application/json");

            var response = await _domoHttpClient.Client.PutAsync(datasetUri, content);

            return response;
        }

        /// <summary>
		/// Imports data into an existing dataset. Replaces all data in dataset.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="datasetId"></param>
		/// <param name="data"></param>
		/// <returns>Http response from import data request</returns>
        public async Task<HttpResponseMessage> ImportDataAsync(string datasetId, string data)
        {
            string datasetUri = $"v1/datasets/{datasetId}/data";
            _domoHttpClient.SetContentType("text/csv");

            StringContent content = new StringContent(data);

            var response = await _domoHttpClient.Client.PutAsync(datasetUri, content);

            return response;
        }
    }
}
