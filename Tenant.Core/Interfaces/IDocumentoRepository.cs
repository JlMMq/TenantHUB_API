using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant.Core.Responses.Documento;

namespace Tenant.Core.Interfaces
{
    public interface IDocumentoRepository
    {
        Task<IEnumerable<SP_LIST_DOCUMENTO_GEN_Response>> ListadoGeneralDocumentos();
    }
}
