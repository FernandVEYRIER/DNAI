﻿namespace CoreCommand.Reply
{
    [ProtoBuf.ProtoContract]
    public class SetContextParent
    {
        [ProtoBuf.ProtoMember(1)]
        public Command.SetContextParent Command { get; set; }
    }
}