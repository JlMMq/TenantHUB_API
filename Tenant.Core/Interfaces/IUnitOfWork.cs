﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenant.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository BaseRepository { get; }
        IDocumentoRepository DocumentoRepository { get; }
        IInquilinoRepository InquilinoRepository { get; }
    }
}
