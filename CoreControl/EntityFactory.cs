﻿using System;
using System.Collections.Generic;

namespace CoreControl
{
    /// <summary>
    /// Class that is used to manipulate entities
    /// </summary>
    public class EntityFactory
    {
        /// <summary>
        /// Ids of entities created by default
        /// </summary>
        public enum BASE_ID : uint
        {
            GLOBAL_CTX = 0,
            BOOLEAN_TYPE = 1,
            INTEGER_TYPE = 2,
            FLOATING_TYPE = 3,
            CHARACTER_TYPE = 4,
            STRING_TYPE = 5
        }

        /// <summary>
        /// Enumeration that represents an entity visibility at declaration
        /// </summary>
        /// <remarks>Makes a transition in order to hide CorePackage.Global.AccessMode enum</remarks>
        public enum VISIBILITY
        {
            PUBLIC = CorePackage.Global.AccessMode.EXTERNAL,
            PRIVATE = CorePackage.Global.AccessMode.INTERNAL
        }

        /// <summary>
        /// Enumeration that represents a declarable entity
        /// </summary>
        public enum ENTITY
        {
            CONTEXT,
            VARIABLE,
            FUNCTION,
            DATA_TYPE,
            ENUM_TYPE,
            OBJECT_TYPE,
            LIST_TYPE
        }

        public struct Entity
        {
            public EntityFactory.ENTITY Type { get; set; }

            public string Name { get; set; }

            public UInt32 Id { get; set; }

        }

        /// <summary>
        /// Associates an id to its entity definition
        /// </summary>
        private Dictionary<UInt32, CorePackage.Global.Definition> definitions = new Dictionary<uint, CorePackage.Global.Definition>();

        /// <summary>
        /// Associates an entity definition to its id
        /// </summary>
        private Dictionary<CorePackage.Global.Definition, UInt32> ids = new Dictionary<CorePackage.Global.Definition, uint>();

        /// <summary>
        /// Represents the id of the next entity that will be declared
        /// </summary>
        private UInt32 current_uid = 0;

        /// <summary>
        /// Default constructor that add default entities (global context and scalar types)
        /// </summary>
        public EntityFactory()
        {
            //global context is in 0
            AddEntity(new CorePackage.Entity.Context());

            //boolean type is in 1
            AddEntity(CorePackage.Entity.Type.Scalar.Boolean);

            //integer type is in 2
            AddEntity(CorePackage.Entity.Type.Scalar.Integer);

            //floating type is in 3
            AddEntity(CorePackage.Entity.Type.Scalar.Floating);

            //character type is in 4
            AddEntity(CorePackage.Entity.Type.Scalar.Character);

            //string type is in 5
            AddEntity(CorePackage.Entity.Type.Scalar.String);
        }

        /// <summary>
        /// Getter for the current id
        /// </summary>
        public UInt32 CurrentID
        {
            get { return current_uid; }
        }

        /// <summary>
        /// Getter for the id of the last entity declared
        /// </summary>
        public UInt32 LastID
        {
            get { return CurrentID - 1; }
        }

        /// <summary>
        /// Creates an entity and add it the the dictionnaries
        /// </summary>
        /// <typeparam name="T">Type of the entity to declare</typeparam>
        /// <returns>Freshly instanciated entity</returns>
        public T Create<T>() where T : CorePackage.Global.Definition
        {
            T toadd = (T)Activator.CreateInstance(typeof(T));

            AddEntity(toadd);
            return toadd;
        }

        /// <summary>
        /// Add an entity to the internal dictionnaries and increment current_id
        /// </summary>
        /// <param name="entity">Entity to add</param>
        public void AddEntity(CorePackage.Global.Definition entity)
        {
            definitions[current_uid] = entity;
            ids[entity] = current_uid++;
        }

        /// <summary>
        /// Remove an entity from the internal dictionaries
        /// </summary>
        /// <remarks>
        /// Throws an InvalidOperationException if trying to remove default added entity
        /// Throws a KeyNotFoundException if an entity is not identified by the given id
        /// </remarks>
        /// <param name="definition_uid">Identifier of the entity to remove</param>
        public void RemoveEntity(UInt32 definition_uid)
        {
            if (definition_uid <= 5)
                throw new InvalidOperationException("EntityFactory.remove : cannot remove base entities");

            if (!definitions.ContainsKey(definition_uid))
                throw new KeyNotFoundException("EntityFactory.remove : given definition uid hasn't been found");

            ids.Remove(definitions[definition_uid]);
            definitions.Remove(definition_uid);
        }

        /// <summary>
        /// Removes an entity from the internal dictionaries
        /// </summary>
        /// <remarks>
        /// Throws a KeyNotFoundException if the entity hasn't been found
        /// Throws an InvalidOperationException if the given entity is a default added entity
        /// </remarks>
        /// <param name="entity">Entity to remove</param>
        public void RemoveEntity(CorePackage.Global.Definition entity)
        {
            if (!ids.ContainsKey(entity))
                throw new KeyNotFoundException("EntityFactory.remove : given definition uid hasn't been found");

            uint entity_id = ids[entity];

            if (entity_id <= 5)
                throw new InvalidOperationException("EntityFactory.remove : cannot remove base entities");

            definitions.Remove(entity_id);
            ids.Remove(entity);
        }

        /// <summary>
        /// Find an entity in the dictionaries
        /// </summary>
        /// <remarks>Throws a KeyNotFoundException if entity hasn't been found</remarks>
        /// <param name="definition_uid">Identifier of an entity</param>
        /// <returns>The entity to find</returns>
        public CorePackage.Global.Definition Find(UInt32 definition_uid)
        {
            if (!definitions.ContainsKey(definition_uid))
                throw new KeyNotFoundException("EntityFactory.find : given definition of id " + definition_uid.ToString() + " hasn't been found");

            return definitions[definition_uid];
        }

        /// <summary>
        /// Find basic an entity from its id
        /// </summary>
        /// <param name="definition_uid">Identifier of the basic entity</param>
        /// <returns>Basic entity to find</returns>
        public CorePackage.Global.Definition Find(BASE_ID definition_uid)
        {
            return Find((uint)definition_uid);
        }

        /// <summary>
        /// Returns the id of an entity in the internal dicitonaries
        /// </summary>
        /// <param name="entity">Entity for which find the id</param>
        /// <returns>Id of the given entity</returns>
        public UInt32 GetEntityID(CorePackage.Global.Definition entity)
        {
            if (ids.ContainsKey(entity))
                return ids[entity];
            throw new KeyNotFoundException("EntityFactory.getEntityID : No such id for the given entity");
        }

        /// <summary>
        /// Find a definition of a specific type
        /// </summary>
        /// <remarks>Throws an InvalidCastException if the type doesn't match</remarks>
        /// <typeparam name="T">Type of the entity to find</typeparam>
        /// <param name="id">Identifier of the entity to find</param>
        /// <returns>The entity to find</returns>
        public T FindDefinitionOfType<T>(UInt32 id) where T : class
        {
            CorePackage.Global.Definition to_find = Find(id);
            T to_ret = to_find as T;

            if (to_ret == null)
                throw new InvalidCastException("Unable to cast entity with id " + id.ToString() + " (of type " + to_find.GetType().ToString() + ") into " + typeof(T).ToString());
            return to_ret;
        }

        /// <summary>
        /// Find a declarator of a specific entity type
        /// </summary>
        /// <typeparam name="T">Type of the entity used in the declarators</typeparam>
        /// <param name="id">Identifier of the declarator to find</param>
        /// <returns>The declarator to find</returns>
        public CorePackage.Global.IDeclarator GetDeclaratorOf(UInt32 id)
        {
            return FindDefinitionOfType<CorePackage.Global.IDeclarator>(id);
        }

        /// <summary>
        /// Declare an entity into a specific declarator
        /// </summary>
        /// <typeparam name="Entity">Type of the entity to declare</typeparam>
        /// <typeparam name="Declarator">Type used in the declarator</typeparam>
        /// <param name="containerID">Identifier of the declarator in which declare entity</param>
        /// <param name="name">Name of the entity to declare</param>
        /// <param name="visibility">Visibility of the entity to declare</param>
        /// <returns>The identifier of the freshly declared entity</returns>
        public UInt32 Declare<Entity>(UInt32 containerID, string name, CorePackage.Global.AccessMode visibility)
            where Entity : CorePackage.Global.Definition
        {
            GetDeclaratorOf(containerID).Declare(Create<Entity>(), name, visibility);
            return LastID;
        }

        /// <summary>
        /// Remove an entity from a specific container
        /// </summary>
        /// <typeparam name="T">Type of the entity used in the declarator</typeparam>
        /// <param name="containerID">Identifier of the container from which remove the entity</param>
        /// <param name="name">Name of the entity to remove</param>
        /// <returns>List of all removed entities' id</returns>
        public List<UInt32> Remove(UInt32 containerID, string name)
        {
            CorePackage.Global.Definition entity = GetDeclaratorOf(containerID).Pop(name);
            List<UInt32> removed = new List<uint> { GetEntityID(entity) };

            RemoveEntity(entity);

            Stack<CorePackage.Global.IDeclarator> toclear = new Stack<CorePackage.Global.IDeclarator>();

            CorePackage.Global.IDeclarator decl = entity as CorePackage.Global.IDeclarator;

            if (decl != null)
                toclear.Push(decl);

            while (toclear.Count > 0)
            {
                CorePackage.Global.IDeclarator declarator = toclear.Pop();

                foreach (CorePackage.Global.Definition curr in declarator.Clear())
                {
                    removed.Add(GetEntityID(curr));
                    decl = curr as CorePackage.Global.IDeclarator;
                    if (decl != null)
                        toclear.Push(decl);
                }
            }
            return removed;
        }

        /// <summary>
        /// Rename an entity in a specific declarator
        /// </summary>
        /// <typeparam name="T">Type of the entity used in the declarator</typeparam>
        /// <param name="containerID">Identifier of the container in which rename the entity</param>
        /// <param name="lastName">Current name of the entity to rename</param>
        /// <param name="newName">Name to set to the entity</param>
        public void Rename(UInt32 containerID, string lastName, string newName)
        {
            GetDeclaratorOf(containerID).Rename(lastName, newName);
        }

        /// <summary>
        /// Move an entity from a declarator to another
        /// </summary>
        /// <typeparam name="T">Type of the entity used in declarators</typeparam>
        /// <param name="fromID">Identifier of the declarator that contains the entity</param>
        /// <param name="toID">Identifier of the declarator to which move the entity</param>
        /// <param name="name">Name of the entity to move</param>
        public void Move(UInt32 fromID, UInt32 toID, string name)
        {
            CorePackage.Global.IDeclarator from = GetDeclaratorOf(fromID);
            CorePackage.Global.IDeclarator to = GetDeclaratorOf(toID);

            CorePackage.Global.AccessMode visibility = from.GetVisibilityOf(name);
            CorePackage.Global.Definition definition = from.Pop(name);
            to.Declare(definition, name, visibility);
        }

        /// <summary>
        /// Change an entity visibility in a specific declarator
        /// </summary>
        /// <typeparam name="T">Type of the entity used in the declarator</typeparam>
        /// <param name="containerID">Identifier of the declarator in which change entity visibility</param>
        /// <param name="name">Name of the entity to which change visibility</param>
        /// <param name="newVisi">New visibility to set</param>
        public void ChangeVisibility(UInt32 containerID, string name, VISIBILITY newVisi)
        {
            GetDeclaratorOf(containerID).ChangeVisibility(name, (CorePackage.Global.AccessMode)newVisi);
        }
        
        /// <summary>
        /// Get the list of entities of a speficic type in a specific container
        /// </summary>
        /// <typeparam name="T">Type of entities to find in container</typeparam>
        /// <param name="containerID">Identifier of the container</param>
        /// <returns>List of declared entities</returns>
        public Dictionary<string, dynamic> GetEntitiesOfType(UInt32 containerID)
        {
            Dictionary<string, CorePackage.Global.Definition> real = GetDeclaratorOf(containerID).GetEntities(CorePackage.Global.AccessMode.EXTERNAL);
            Dictionary<string, dynamic> to_ret = new Dictionary<string, dynamic>();

            foreach (KeyValuePair<string, CorePackage.Global.Definition> curr in real)
            {
                to_ret.Add(curr.Key, curr.Value);
            }
            return to_ret;
        }

        /// <summary>
        /// Associates a EntityFactory.declare function to a specific ENTITY key
        /// </summary>
        static private readonly Dictionary<ENTITY, Func<EntityFactory, UInt32, string, VISIBILITY, UInt32>> declarators = new Dictionary<ENTITY, Func<EntityFactory, uint, string, VISIBILITY, uint>>
        {
            {
                ENTITY.CONTEXT,
                (EntityFactory factory, UInt32 containerID, string name, VISIBILITY visibility) =>
                {
                    return factory.Declare<CorePackage.Entity.Context>(containerID, name, (CorePackage.Global.AccessMode)visibility);
                }
            },
            {
                ENTITY.VARIABLE,
                (EntityFactory factory, UInt32 containerID, string name, VISIBILITY visibility) =>
                {
                    return factory.Declare<CorePackage.Entity.Variable>(containerID, name, (CorePackage.Global.AccessMode)visibility);
                }
            },
            {
                ENTITY.FUNCTION,
                (EntityFactory factory, UInt32 containerID, string name, VISIBILITY visibility) =>
                {
                    return factory.Declare<CorePackage.Entity.Function>(containerID, name, (CorePackage.Global.AccessMode)visibility);
                }
            },
            {
                ENTITY.ENUM_TYPE,
                (EntityFactory factory, UInt32 containerID, string name, VISIBILITY visibility) =>
                {
                    return factory.Declare<CorePackage.Entity.Type.EnumType>(containerID, name, (CorePackage.Global.AccessMode)visibility);
                }
            },
            {
                ENTITY.OBJECT_TYPE,
                (EntityFactory factory, UInt32 containerID, string name, VISIBILITY visibility) =>
                {
                    return factory.Declare<CorePackage.Entity.Type.ObjectType>(containerID, name, (CorePackage.Global.AccessMode)visibility);
                }
            },
            {
                ENTITY.LIST_TYPE,
                (EntityFactory factory, UInt32 containerID, string name, VISIBILITY visibility) =>
                {
                    return factory.Declare<CorePackage.Entity.Type.ListType>(containerID, name, (CorePackage.Global.AccessMode)visibility);
                }
            }
        };

        /// <summary>
        /// Will declare an entity in a container with a specific name and visibility
        /// </summary>
        /// <param name="to_declare">Type of the entity to declare</param>
        /// <param name="containerID">Identifier of the container in which declare the entity</param>
        /// <param name="name">Name of the declared entity</param>
        /// <param name="visibility">Visibility of the declared entity</param>
        /// <returns>Identifier of the freshly declared entity</returns>
        public UInt32 Declare(ENTITY to_declare, UInt32 containerID, string name, VISIBILITY visibility)
        {
            if (declarators.ContainsKey(to_declare))
                return declarators[to_declare].Invoke(this, containerID, name, visibility);
            throw new KeyNotFoundException("No such declarator for ENTITY: " + to_declare.ToString());
        }

        private static readonly Dictionary<ENTITY, System.Type> entity_types = new Dictionary<ENTITY, Type>
        {
            { ENTITY.CONTEXT, typeof(CorePackage.Entity.Context) },
            { ENTITY.DATA_TYPE, typeof(CorePackage.Entity.DataType) },
            { ENTITY.FUNCTION, typeof(CorePackage.Entity.Function) },
            { ENTITY.VARIABLE, typeof(CorePackage.Entity.Variable) }
        };

        /// <summary>
        /// Method to get entities of a specific type in a given container
        /// </summary>
        /// <param name="entities_type">Type of the entities to return</param>
        /// <param name="containerID">Identifier of the container in which entities are declared</param>
        /// <returns>List of declared entities</returns>
        public List<Entity> GetEntitiesOfType(ENTITY entities_type, UInt32 containerID)
        {
            Dictionary<string, dynamic> entities = GetEntitiesOfType(containerID);
            List<Entity> to_ret = new List<Entity>();
            System.Type tocheck = entity_types[entities_type];

            foreach (KeyValuePair<string, dynamic> curr in entities)
            {
                if (tocheck.IsAssignableFrom(curr.Value.GetType()))
                    to_ret.Add(new Entity
                    {
                        Id = GetEntityID(curr.Value),
                        Name = curr.Key,
                        Type = entities_type
                    });
            }
            return to_ret;
        }
    }
}