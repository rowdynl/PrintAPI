using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rowdy.API.PrintAPI
{
    public interface ResponseBase
    {
       
    }

    public interface RequestBase
    {

    }

    public interface ItemBase
    {
        string productId { get; }
    }
}
