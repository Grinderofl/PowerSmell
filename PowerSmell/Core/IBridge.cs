using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSmell.Core
{
    public interface IBridge
    {
        event EventHandler OutputReceived;
        
    }
}
