using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.Exceptions;

public class InitializationException : Exception
{
    public InitializationException()
     : base()
    { }

    public InitializationException(string message)
       : base(message)
    {
    }
}
