using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolBox.MVVM.Interfaces
{
    public interface ILogs
    {
        void WriteError(Exception ex);
        //void WriteError(string Error);
        //void WriteWarning(string Warning);
    }
}
