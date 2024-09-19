using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenant.Core.Interfaces
{
    public interface IBaseRepository
    {
        Task<bool> DataBaseRun();
    }
}
