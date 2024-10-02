using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenant.Core.Requests.Inquilino
{
    public class SP_INSERT_INQUILINO_Request
    {
        public string str_apellidos {  get; set; }
        public string str_nombres { get; set; }
        public string int_tipoDocmt { get; set; }
        public string str_nroDocmt { get; set; }
        public string str_telefono { get; set; }
        public string str_prefijoPais { get; set; }
        public string? str_direccion { get; set; }
        public string int_tipo { get; set; }
        public byte[]? img_foto { get; set; }
        public byte[]? bin_document{ get; set; }


    }
}
