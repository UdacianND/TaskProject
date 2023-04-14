using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.AppConstants;

public class FilePaths
{
    public static readonly string dataUrl = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\data\\vehicles.xml"));
}
