﻿using CoreControl;

namespace CoreCommand.Command
{
    public class SetFunctionEntryPoint : ICommand<EmptyReply>
    {
        [BinarySerializer.BinaryFormat]
        public uint FunctionId { get; set; }

        [BinarySerializer.BinaryFormat]
        public uint Instruction { get; set; }

        public EmptyReply Resolve(Controller controller)
        {
            controller.SetFunctionEntryPoint(FunctionId, Instruction);
            return null;
        }
    }
}