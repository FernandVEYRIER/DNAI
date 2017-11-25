﻿using static CoreControl.InstructionFactory;

namespace CoreCommand.Command
{
    [ProtoBuf.ProtoContract]
    public class Default
    {
        [ProtoBuf.ProtoMember(1)]
        public Declare Declare { get { return new Declare(); } }

        [ProtoBuf.ProtoMember(2)]
        public Remove Remove { get { return new Remove(); } }

        [ProtoBuf.ProtoMember(3)]
        public SetVariableValue SetVariableValue { get { return new SetVariableValue(); } }
    }
}