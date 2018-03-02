using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuildIntelligence.Domo.Sdk.Datasets
{
    public interface IDomoDatasetClient
    {
        Task<IEnumerable<Dataset>> ListDatasetsAsync(int limit, int offset);
        Task<Dataset> CreateDatasetAsync(IDatasetSchema schema);
        Task<HttpResponseMessage> UpdateDatasetMetadataAsync(string datasetId, IDatasetSchema schema);
        Task<HttpResponseMessage> DeleteDatasetAsync(string datasetId);
        Task<string> RetrieveCsvAsync(string datasetId, bool includeHeader = false);
        Task ExportToCsvFile(string datasetId, string path, bool includeHeader, string fileName);
        Task<Dataset> RetrieveDatasetAsync(string datasetId);
        Task<HttpResponseMessage> ImportDataAsync(string datasetId, string data);
    }
}
