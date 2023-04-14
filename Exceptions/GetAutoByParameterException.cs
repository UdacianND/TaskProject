using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.Exceptions;

public class GetAutoByParameterException : Exception
{
    public GetAutoByParameterException()
    : base()
    { }

    public GetAutoByParameterException(string message)
       : base(message)
    {
    }
}
