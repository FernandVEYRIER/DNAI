﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommand.Reply
{
    [ProtoBuf.ProtoContract]
    public class VariableValueSet
    {
        [ProtoBuf.ProtoMember(1)]
        public Command.SetVariableValue Command { get; set; }
    }
}
