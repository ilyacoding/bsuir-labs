﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTcp.Core.Http.Action
{
    public interface IHttpAction
    {
        int Code { get; set; }
        object Object { get; set; }
    }
}
