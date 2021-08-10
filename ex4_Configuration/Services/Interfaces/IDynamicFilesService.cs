using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex4_Configuration.Services.Interfaces
{
    public interface IDynamicFilesService
    {
        Task CreateAndWrite();
        Task Remove();
    }
}
