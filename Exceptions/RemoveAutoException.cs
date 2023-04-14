using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.Exceptions;

public class RemoveAutoException : Exception
{
    public RemoveAutoException()
    : base()
    { }

    public RemoveAutoException(string message)
       : base(message)
    {
    }
}
