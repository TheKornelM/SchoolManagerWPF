using System.Reflection;
using System.Resources;

namespace SchoolManagerWPF.Utils;

internal static class UIResourceFactory
{
    public static ResourceManager GetNewResource()
    {
        return new ResourceManager("SchoolManagerWPF.Resources.UI",
                Assembly.GetExecutingAssembly());
    }
}
