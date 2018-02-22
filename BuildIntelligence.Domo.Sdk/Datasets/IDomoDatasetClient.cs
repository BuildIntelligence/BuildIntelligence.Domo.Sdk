using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildIntelligence.Domo.Sdk.Datasets
{
    public interface IDomoDatasetClient
    {
        Task<IEnumerable<Dataset>> ListDatasetsAsync(int limit, int offset);
        Task<Dataset> CreateDatasetAsync(IDatasetSchema schema);
        Task<Dataset> UpdateDatasetMetadataAsync(string datasetId, IDatasetSchema schema);
        Task<HttpResponseMessage> DeleteDatasetAsync(string datasetId);
        Task<string> RetrieveCsvAsync(string datasetId, bool includeHeader = false);
        Task ExportToCsvFile(string datasetId, string path, bool includeHeader, string fileName);
        Task<Dataset> RetrieveDatasetAsync(string datasetId);
        Task<HttpResponseMessage> UpdateDatasetMetadataAsync(string datasetId, Dataset datasetSchema);
        Task<HttpResponseMessage> ImportDataAsync<T>(string datasetId, string data);
    }
}
