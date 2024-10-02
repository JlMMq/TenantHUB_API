using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenant.Core.Responses.Inquilino
{
    public class SP_LIST_INQUILINO_GRID_Response
    {
        public int int_codInq {  get; set; }
        public string str_nroDocmt { get; set; }
        public string str_apenom {  get; set; }
        public string str_descTipo { get; set; }
    }

    // Respuesta solo valida para la grilla activa de inquilinos
}
