﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPos.DomainModel.Base
{
    public interface ISoftDeletable
    {
        bool Deleted { get; set; }
    }
}
