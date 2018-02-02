using BiDomoDotNet.Datasets;
using BiDomoDotNet.Groups;
using BiDomoDotNet.Pages;
using BiDomoDotNet.Streams;
using BiDomoDotNet.Users;

namespace BiDomoDotNet
{
    public interface IGotDomod
    {
        IDomoDatasetClient Datasets { get; set; }
        IDomoGroupClient Groups { get; set; }
        IDomoPageClient Pages { get; set; }
        IDomoStreamClient Streams { get; set; }
        IDomoUserClient Users { get; set; }
    }
}
