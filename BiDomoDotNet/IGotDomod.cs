using BiDomoDotNet.Datasets;
using BiDomoDotNet.Groups;
using BiDomoDotNet.Pages;
using BiDomoDotNet.Streams;
using BiDomoDotNet.Users;

namespace BiDomoDotNet
{
    public interface IGotDomod
    {
        /// <summary>
        /// Property for interacting with Datasets API
        /// </summary>
        IDomoDatasetClient Datasets { get; set; }

        /// <summary>
        /// Property for interacting with Groups API
        /// </summary>
        IDomoGroupClient Groups { get; set; }

        /// <summary>
        /// Property for interacting with Pages API
        /// </summary>
        IDomoPageClient Pages { get; set; }

        /// <summary>
        /// Property for interacting with Streams API
        /// </summary>
        IDomoStreamClient Streams { get; set; }

        /// <summary>
        /// Property for interacting with Users API
        /// </summary>
        IDomoUserClient Users { get; set; }
    }
}
