﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreControl.SerializationModel
{
    public class Context
    {
        [BinarySerializer.BinaryFormat]
        public List<UInt32> Children { get; set; }
    }
}
