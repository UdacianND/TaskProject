using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsProject.Exceptions;

public class UpdateAutoException : Exception
{
    public UpdateAutoException()
    : base()
    { }

    public UpdateAutoException(string message)
       : base(message)
    {
    }
}
