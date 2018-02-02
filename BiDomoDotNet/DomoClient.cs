using BiDomoDotNet.Datasets;
using BiDomoDotNet.Groups;
using BiDomoDotNet.Pages;
using BiDomoDotNet.Streams;
using BiDomoDotNet.Users;

namespace BiDomoDotNet
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
