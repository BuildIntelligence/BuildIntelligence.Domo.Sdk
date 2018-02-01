using BiDomoDotNet.Datasets;
using BiDomoDotNet.Groups;
using BiDomoDotNet.Pages;
using BiDomoDotNet.Streams;
using BiDomoDotNet.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet
{
    public class DomoClient
    {
		private DomoConfig _config { get; set; }


		public DomoClient(DomoConfig config)
		{
			_config = config;
			Datasets = new DatasetClient(_config);
			Groups = new GroupClient(_config);
			Pages = new PageClient(_config);
			Streams = new StreamClient(_config);
			Users = new UserClient(_config);
		}

		public DatasetClient Datasets { get; set; }
		public GroupClient Groups { get; set; }
		public PageClient Pages { get; set; }
		public StreamClient Streams { get; set; }
		public UserClient Users { get; set; }
	}
}
