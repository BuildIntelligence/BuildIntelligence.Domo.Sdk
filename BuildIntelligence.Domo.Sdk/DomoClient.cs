using BuildIntelligence.Domo.Sdk.Datasets;
using BuildIntelligence.Domo.Sdk.Groups;
using BuildIntelligence.Domo.Sdk.Pages;
using BuildIntelligence.Domo.Sdk.Streams;
using BuildIntelligence.Domo.Sdk.Users;

namespace BuildIntelligence.Domo.Sdk
{
    public class DomoClient : IGotDomod
    {
		private IDomoConfig _config { get; set; }


		public DomoClient(IDomoConfig config)
		{
			_config = config;
			Datasets = new DatasetClient(_config);
			Groups = new GroupClient(_config);
			Pages = new PageClient(_config);
			Streams = new StreamClient(_config);
			Users = new UserClient(_config);
		}

		public IDomoDatasetClient Datasets { get; set; }
		public IDomoGroupClient Groups { get; set; }
		public IDomoPageClient Pages { get; set; }
		public IDomoStreamClient Streams { get; set; }
		public IDomoUserClient Users { get; set; }
	}
}
