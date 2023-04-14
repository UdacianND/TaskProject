using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.Exceptions;

public class AddException : Exception
{
    public AddException()
     : base()
    { }

    public AddException(string message)
       : base(message)
    {
    }
}
