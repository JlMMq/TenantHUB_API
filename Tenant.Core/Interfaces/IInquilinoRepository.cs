using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant.Core.Requests.Inquilino;
using Tenant.Core.Responses.Inquilino;

namespace Tenant.Core.Interfaces
{
    public interface IInquilinoRepository
    {
        Task<IEnumerable<SP_LIST_INQUILINO_GRID_Response>> ListadoGrillaInquilino();
        Task<int> InsertarInquilino(SP_INSERT_INQUILINO_Request obj);
    }
}
