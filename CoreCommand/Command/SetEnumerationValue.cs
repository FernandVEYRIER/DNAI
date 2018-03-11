﻿using CoreControl;
using Newtonsoft.Json;

namespace CoreCommand.Command
{
    public class SetEnumerationValue : ICommand<EmptyReply>
    {
        [BinarySerializer.BinaryFormat]
        public uint EnumId { get; set; }

        [BinarySerializer.BinaryFormat]
        public string Name { get; set; }

        [BinarySerializer.BinaryFormat]
        public string Value { get; set; }

        public EmptyReply Resolve(Controller controller)
        {
            controller.SetEnumerationValue(EnumId, Name, JsonConvert.DeserializeObject(Value));
            return null;
        }
    }
}