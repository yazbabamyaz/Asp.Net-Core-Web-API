using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    //newleme yok- yarım bırakılmış class gibi düşün...
    public abstract class NotFoundException:Exception
    {
        //newlenemediği için ctor un public olması saçma olur.
        
        protected NotFoundException(string message):base(message)
        {

        }
    }
}
