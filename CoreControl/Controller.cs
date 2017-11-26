﻿using System;
using System.Collections.Generic;

namespace CoreControl
{
    /// <summary>
    /// Class that is used to control the core model without having to access to any type of it
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Entity factory used to manage entities
        /// </summary>
        private EntityFactory entity_factory = new EntityFactory();

        /// <summary>
        /// Will declare an entity in a container with a specific name and visibility
        /// </summary>
        /// <param name="entity_type">Type of the entity to declare</param>
        /// <param name="containerID">Identifier of the container in which declare the entity</param>
        /// <param name="name">Name of the declared entity</param>
        /// <param name="visibility">Visibility of the declared entity</param>
        /// <returns>Identifier of the freshly declared entity</returns>
        public UInt32 Declare(EntityFactory.ENTITY entity_type, UInt32 containerID, string name, EntityFactory.VISIBILITY visibility)
        {
            return entity_factory.Declare(entity_type, containerID, name, visibility);
        }

        /// <summary>
        /// Remove an entity declared in a container
        /// </summary>
        /// <param name="entity_type">Type of entity contained in the declarator</param>
        /// <param name="containerID">Identifier of the container in which entity is declared</param>
        /// <param name="name">Name of the entity to remove in the container</param>
        /// <returns>List of all removed entities' id</returns>
        public List<UInt32> Remove(EntityFactory.ENTITY entity_type, UInt32 containerID, string name)
        {
            return entity_factory.Remove(entity_type, containerID, name);
        }

        /// <summary>
        /// Rename an entity declared in a container
        /// </summary>
        /// <param name="entity_type">Type of the entity contained in the declarator</param>
        /// <param name="containerID">Identifier of the container in which entity is declared</param>
        /// <param name="lastName">Current name of the entity</param>
        /// <param name="newName">New name to set</param>
        public void Rename(EntityFactory.ENTITY entity_type, UInt32 containerID, string lastName, string newName)
        {
            entity_factory.Rename(entity_type, containerID, lastName, newName);
        }

        /// <summary>
        /// Move an entity from a specific container to another
        /// </summary>
        /// <param name="entity_type">Type of the entity contained in the declarator</param>
        /// <param name="fromID">Identifier of the entity declared in the container</param>
        /// <param name="toID">Identifier of the declarator in which move the entity</param>
        /// <param name="name">Name of the entity to move</param>
        public void Move(EntityFactory.ENTITY entity_type, UInt32 fromID, UInt32 toID, string name)
        {
            entity_factory.Move(entity_type, fromID, toID, name);
        }

        /// <summary>
        /// Change an entity visibility declared in a specific container
        /// </summary>
        /// <param name="entity_type">Type of the entity to change visibility</param>
        /// <param name="containerID">Identifier of the container in which entity is declared</param>
        /// <param name="name">Name of the declared entity in the container</param>
        /// <param name="newVisi">New visibility of the declared entity</param>
        public void ChangeVisibility(EntityFactory.ENTITY entity_type, UInt32 containerID, string name, EntityFactory.VISIBILITY newVisi)
        {
            entity_factory.ChangeVisibility(entity_type, containerID, name, newVisi);
        }

        /// <summary>
        /// Set a specific value to a variable
        /// </summary>
        /// <param name="variableID">Identifier of the variable</param>
        /// <param name="value">Value to set to the variable</param>
        public void SetVariableValue(UInt32 variableID, dynamic value)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Variable>(variableID).Value = value;
        }

        /// <summary>
        /// Set a specific type to a variable
        /// </summary>
        /// <param name="variableID">Identifier of the variable to which set the type</param>
        /// <param name="typeID">Identifier of the type to set</param>
        public void SetVariableType(UInt32 variableID, UInt32 typeID)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Variable>(variableID).Type = entity_factory.FindDefinitionOfType<CorePackage.Entity.DataType>(typeID);
        }

        /// <summary>
        /// Resets the controller state to initial values.
        /// </summary>
        public void Reset()
        {
            entity_factory = new EntityFactory();
        }

        /// <summary>
        /// Get a variable value
        /// </summary>
        /// <param name="variableID">Identifier of the variable from which retreive the value</param>
        /// <returns>Value of the variable identified by the given id</returns>
        public dynamic GetVariableValue(UInt32 variableID)
        {
            return entity_factory.FindDefinitionOfType<CorePackage.Entity.Variable>(variableID).Value;
        }

        /// <summary>
        /// Set a parent context to a specific context
        /// </summary>
        /// <param name="contextID">Identifier of the context to which set the parent</param>
        /// <param name="parentID">Identifier of the parent context to set</param>
        public void SetContextParent(UInt32 contextID, UInt32 parentID)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Global.IContext>(contextID).SetParent(entity_factory.FindDefinitionOfType<CorePackage.Global.IContext>(parentID));
        }

        /// <summary>
        /// Set a type stored in a specific enumeration
        /// </summary>
        /// <param name="enumID">Identifier of the enumeration to which set stored type</param>
        /// <param name="typeID">Identifier of the type to set into the enum</param>
        public void SetEnumerationType(UInt32 enumID, UInt32 typeID)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.EnumType>(enumID).Stored = entity_factory.FindDefinitionOfType<CorePackage.Entity.DataType>(typeID);
        }

        /// <summary>
        /// Set an enumeration value
        /// </summary>
        /// <param name="enumID">Identifier of specific enumeration</param>
        /// <param name="name">Name of the enum value to set</param>
        /// <param name="value">Value to set in the enum</param>
        public void SetEnumerationValue(UInt32 enumID, string name, dynamic value)
        {
            CorePackage.Entity.Type.EnumType to_find = entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.EnumType>(enumID);
            CorePackage.Entity.Variable var = new CorePackage.Entity.Variable(to_find.Stored, value);
            to_find.SetValue(name, var);
        }

        /// <summary>
        /// Get an enumeration value
        /// </summary>
        /// <param name="enumID">Identifier of a specific enumeration</param>
        /// <param name="name">Name of an enum value</param>
        /// <returns>Value to retreive</returns>
        public dynamic GetEnumerationValue(UInt32 enumID, string name)
        {
            return entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.EnumType>(enumID).GetValue(name).Value;
        }

        /// <summary>
        /// Remove a specific enum value
        /// </summary>
        /// <param name="enumID">Identifier of a specific enumeration</param>
        /// <param name="name">Name of an enum value</param>
        public void RemoveEnumerationValue(UInt32 enumID, string name)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.EnumType>(enumID).RemoveValue(name);
        }

        /// <summary>
        /// Add an attribute to a class
        /// </summary>
        /// <param name="classID">Identifier of a specific class</param>
        /// <param name="name">Name of the attribute to add</param>
        /// <param name="typeID">Identifier of the attribute type to add</param>
        /// <param name="visibility">Visibility of the attribute to add</param>
        public void AddClassAttribute(UInt32 classID, string name, UInt32 typeID, EntityFactory.VISIBILITY visibility)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.ObjectType>(classID).AddAttribute(name, entity_factory.FindDefinitionOfType<CorePackage.Entity.DataType>(typeID), (CorePackage.Global.AccessMode)visibility);
        }

        /// <summary>
        /// Rename an attribute in a class
        /// </summary>
        /// <param name="classID">Identifier of a specific class</param>
        /// <param name="lastName">Current name of the attribute to rename</param>
        /// <param name="newName">Name to set to the attribute</param>
        public void RenameClassAttribute(UInt32 classID, string lastName, string newName)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.ObjectType>(classID).RenameAttribute(lastName, newName);
        }

        /// <summary>
        /// Remove an attribute in a class
        /// </summary>
        /// <param name="classID">Identifier of a specific class</param>
        /// <param name="name">Name of the attribute to remove</param>
        public void RemoveClassAttribute(UInt32 classID, string name)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.ObjectType>(classID).RemoveAttribute(name);
        }

        /// <summary>
        /// Add a member function to a class
        /// </summary>
        /// <remarks>Will declare a function where the first argument is 'this' reference</remarks>
        /// <param name="classID">Identifier of a specific class</param>
        /// <param name="name">Name of the method to add</param>
        /// <param name="visibility">Visibility of the method to add</param>
        /// <returns>Identifier of the new function added</returns>
        public UInt32 AddClassMemberFunction(UInt32 classID, string name, EntityFactory.VISIBILITY visibility)
        {
            UInt32 funcID = entity_factory.Declare<CorePackage.Entity.Function>(classID, name, (CorePackage.Global.AccessMode)visibility);
            CorePackage.Entity.Type.ObjectType obj = entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.ObjectType>(classID);
            CorePackage.Entity.Function func = ((CorePackage.Global.IDeclarator<CorePackage.Entity.Function>)obj).Find(name, (CorePackage.Global.AccessMode)visibility);

            func.Declare(new CorePackage.Entity.Variable(obj), "this", CorePackage.Global.AccessMode.EXTERNAL);
            func.SetVariableAs("this", CorePackage.Entity.Function.VariableRole.PARAMETER);
            return funcID;
        }

        public dynamic GetEnumerationValue(object enumId, object name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set a type to a specific list
        /// </summary>
        /// <param name="listID">Identifier of the list to which set the type</param>
        /// <param name="typeID">Identifier of the type to set in the list</param>
        public void SetListType(UInt32 listID, UInt32 typeID)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Type.ListType>(listID).Stored = entity_factory.FindDefinitionOfType<CorePackage.Entity.DataType>(typeID);
        }

        /// <summary>
        /// Call a specific function with specific parameters
        /// </summary>
        /// <param name="funcID">Identifier of a specific function to call</param>
        /// <param name="parameters">Dictionary of parameters to set</param>
        /// <returns>Dictionary that contains function returns' value</returns>
        public Dictionary<string, dynamic> CallFunction(UInt32 funcID, Dictionary<string, dynamic> parameters)
        {
            Dictionary<string, dynamic> returns = new Dictionary<string, dynamic>();

            CorePackage.Entity.Function to_call = entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(funcID);

            foreach (KeyValuePair<string, dynamic> param in parameters)
            {
                to_call.SetParameterValue(param.Key, param.Value);
            }
            to_call.Call();

            foreach (KeyValuePair<string, CorePackage.Entity.Variable> ret in to_call.Returns)
            {
                returns[ret.Key] = ret.Value.Value;
            }
            return returns;
        }

        /// <summary>
        /// Set a function public variable as parameter
        /// </summary>
        /// <param name="funcID">Identifier of the function in which set the parameter</param>
        /// <param name="externalVarName">Name of the public variable to set as parameter</param>
        public void SetFunctionParameter(UInt32 funcID, string externalVarName)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(funcID).SetVariableAs(externalVarName, CorePackage.Entity.Function.VariableRole.PARAMETER);
        }

        /// <summary>
        /// Set a function public variable as return
        /// </summary>
        /// <param name="funcID">Identifier of specific function</param>
        /// <param name="externalVarName">Name of an external variable to set as return</param>
        public void SetFunctionReturn(UInt32 funcID, string externalVarName)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(funcID).SetVariableAs(externalVarName, CorePackage.Entity.Function.VariableRole.RETURN);
        }

        /// <summary>
        /// Set an instruction as entry point in a function
        /// </summary>
        /// <param name="functionID">Identifier of a function to which set entry point</param>
        /// <param name="instruction">Identifier of an instruction in the function</param>
        public void SetFunctionEntryPoint(UInt32 functionID, UInt32 instruction)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(functionID).setEntryPoint(instruction);
        }

        /// <summary>
        /// Remove an instruction from a specific function
        /// </summary>
        /// <param name="functionID">Identifier of a specific function</param>
        /// <param name="instruction">Identifier of an instruction to remove from the function</param>
        public void RemoveFunctionInstruction(UInt32 functionID, UInt32 instruction)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(functionID).removeInstruction(instruction);
            //could be nice to return the ids that have been data unlinked
            //could be nice to return the ids that have been exec unlinked
        }

        /// <summary>
        /// Add an instruction to a specific function
        /// </summary>
        /// <param name="functionID">Identifier of a specific function</param>
        /// <param name="to_create">Type of instruction to add</param>
        /// <param name="crea_args">List of entities' identifier to send to the instruction constructor</param>
        /// <returns>The identifier of the created instruction</returns>
        public UInt32 AddInstruction(UInt32 functionID, InstructionFactory.INSTRUCTION_ID to_create, List<UInt32> crea_args)
        {
            CorePackage.Entity.Function func = entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(functionID);
            List<CorePackage.Global.Definition> crea_definitions = new List<CorePackage.Global.Definition>();

            foreach (UInt32 definitionID in crea_args)
            {
                crea_definitions.Add(entity_factory.Find(definitionID));
            }
            return func.addInstruction(InstructionFactory.CreateInstruction(to_create, crea_definitions));
        }

        /// <summary>
        /// Link an execution pin of an instruction to another in a specific function
        /// </summary>
        /// <param name="functionID">Identifier of the function in which retreive the instructions</param>
        /// <param name="fromID">Instruction from which link the execution pin</param>
        /// <param name="outIndex">Index of the pin used for the link</param>
        /// <param name="toID">Instruction to link</param>
        public void LinkInstructionExecution(UInt32 functionID, UInt32 fromID, UInt32 outIndex, UInt32 toID)
        {
            CorePackage.Entity.Function func = entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(functionID);

            func.findInstruction<CorePackage.Execution.ExecutionRefreshInstruction>(fromID).LinkTo(outIndex, func.findInstruction<CorePackage.Execution.ExecutionRefreshInstruction>(toID));
        }

        /// <summary>
        /// Link an input pin of an instruction to an output pin of another in a specific function
        /// </summary>
        /// <param name="functionID">Identifier of the function in which retreive the instructions</param>
        /// <param name="fromID">Identifier of the instruction from which link the output</param>
        /// <param name="outputName">Name of the output to link</param>
        /// <param name="toID">Identifier of the instruction to which link to input</param>
        /// <param name="intputName">Name of the input to link</param>
        public void LinkInstructionData(UInt32 functionID, UInt32 fromID, string outputName, UInt32 toID, string intputName)
        {
            CorePackage.Entity.Function func = entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(functionID);

            func.findInstruction<CorePackage.Execution.Instruction>(toID).GetInput(intputName).LinkTo(func.findInstruction<CorePackage.Execution.Instruction>(fromID), outputName);
        }

        /// <summary>
        /// Set an input value of an instruction in a specific function
        /// </summary>
        /// <param name="functionID">Identifier of the function from which retreive the instruction</param>
        /// <param name="instruction">Identifier of the instruction that contains the input to set</param>
        /// <param name="inputname">Name of the input to which set the value</param>
        /// <param name="inputValue">Value to set to the input</param>
        public void SetInstructionInputValue(UInt32 functionID, UInt32 instruction, string inputname, dynamic inputValue)
        {
            CorePackage.Entity.Function func = entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(functionID);

            func.findInstruction<CorePackage.Execution.Instruction>(instruction).SetInputValue(inputname, inputValue);
        }

        /// <summary>
        /// Unlink an execution pin of an instruction in a specific function
        /// </summary>
        /// <param name="functionID">Identifier of the function that contains the instruction to unlink</param>
        /// <param name="instruction">Identifier of the instruction to unlink in the function</param>
        /// <param name="outIndex">Index of the pin to unlink in the instruction</param>
        public void UnlinkInstructionFlow(UInt32 functionID, UInt32 instruction, uint outIndex)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(functionID).findInstruction<CorePackage.Execution.ExecutionRefreshInstruction>(instruction).Unlink(outIndex);
        }

        /// <summary>
        /// Unlink an input of an instruction in a specific function
        /// </summary>
        /// <param name="functionID">Identifier of the function that contains the instruction</param>
        /// <param name="instruction">Identifier of the instruction to unlink in the function</param>
        /// <param name="inputname">Name of the input to unlink</param>
        public void UnlinkInstructionInput(UInt32 functionID, UInt32 instruction, string inputname)
        {
            entity_factory.FindDefinitionOfType<CorePackage.Entity.Function>(functionID).findInstruction<CorePackage.Execution.Instruction>(instruction).GetInput(inputname).Unlink();
        }
    }
}