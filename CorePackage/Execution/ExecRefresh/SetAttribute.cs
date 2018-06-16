﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackage.Execution
{
    public class SetAttribute : ExecutionRefreshInstruction
    {
        List<String> attributes = new List<String>();

        public SetAttribute(Entity.Type.ObjectType type) : base()
        {
            AddInput("this", new Entity.Variable(type), true);
            foreach (KeyValuePair<string, Global.IDefinition> curr in type.GetAttributes())
            {
                Entity.Variable definition = new Entity.Variable((Entity.DataType)curr.Value);
                AddInput(curr.Key, definition); //each time the node is executed, input are refreshed
                AddOutput(curr.Key, definition); //if the definition of output is the same as the input they will be refreshed too
                attributes.Add(curr.Key);
            }
        }

        public override void Execute()
        {
            Entity.Variable objReference = GetInput("this").Definition;

            foreach (String curr in attributes)
            {
                objReference.Value[curr] = GetInputValue(curr);
            }
        }
    }
}
