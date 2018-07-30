﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Core.Plugin.Unity.Generator
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class GeneratedCodeTemplate : GeneratedCodeTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System;
using UnityEngine;
using UnityEngine.Events;
using CoreCommand;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEditor;
using Core.Plugin.Unity.Editor.Conditions.Inspector;
using Core.Plugin.Unity.Editor.Conditions;

namespace DNAI.");
            
            #line 18 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n\t//namespace ");
            
            #line 20 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"
	//{
		[Serializable]
		public class UnityEventOutputChange : UnityEvent<EventOutputChange>
		{
		}

		[System.Serializable]
		public class ConditionItem /*: ScriptableObject*/
		{
			[SerializeField]
			public ACondition cdt;
			public string Test;

			public static readonly string[] Outputs = new string[]
			{
				""No Output Selected"",
				");
            
            #line 37 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Outputs)
				{ 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\"");
            
            #line 39 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\",\r\n\t\t\t\t\t/*\"DNAI.MoreOrLess.COMPARISON enum\",*/\r\n\t\t\t\t");
            
            #line 41 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"			};

			public UnityEventOutputChange OnOutputChanged;
			public int CallbackCount = 0;

			private float drawSize = 0;

			public float ItemSize
			{
				get { return 110f + ((CallbackCount > 1) ? (CallbackCount - 1) * 45f : 0f) + drawSize; }
			}

			[SerializeField]
			private int _selectedIndex;

			public int SelectedIndex
			{
				get { return _selectedIndex; }
				set
				{
					if (value != _selectedIndex)
					{
						_selectedIndex = value;
						cdt.SetCurrentType(SelectedOutput.Split(' ')[0]);
						cdt.SetRefOutput(SelectedOutput[value]);
					}
				}
			}

			public string SelectedOutput { get { return Outputs[SelectedIndex]; } }

			public void Initialize()
			{
				cdt = new ACondition();
				cdt.SetCurrentType(SelectedOutput.Split(' ')[0]);
			
				");
            
            #line 78 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in EnumNames)
				{
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\tcdt.RegisterEnum(typeof(");
            
            #line 80 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 80 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(").AssemblyQualifiedName);\r\n\t\t\t\t");
            
            #line 81 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"			}

			public float Draw(Rect rect)
			{
				//if (cdt != null)
				//if (cdt.CurrentType == null)
					//cdt.SetCurrentType(SelectedOutput.Split(' ')[0]);
				if (_selectedIndex > 0)
					drawSize = cdt.Draw(rect);
				return drawSize;
			}

			public bool Evaluate<T>(T value)
			{
				//if (cdt != null)
				if (_selectedIndex > 0)
					return cdt.Evaluate(value);
				return true;
			}
		}

		[CustomEditor(typeof(");
            
            #line 103 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("), true)]\r\n\t\tpublic class ListExampleInspector : UnityEditor.Editor\r\n\t\t{\r\n\t\t\tpriv" +
                    "ate ReorderableList reorderableList;\r\n\t\t\tprivate int _selectedIndex;\r\n\r\n\t\t\tpriva" +
                    "te ");
            
            #line 109 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" listExample\r\n\t\t\t{\r\n\t\t\t\tget\r\n\t\t\t\t{\r\n\t\t\t\t\treturn target as ");
            
            #line 113 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t\t}\r\n\t\t\t}\r\n\r\n\t\t\tprivate void OnEnable()\r\n\t\t\t{\r\n\t\t\t\treorderableList = new Reo" +
                    "rderableList(listExample._cdtList, typeof(ConditionItem), true, true, true, true" +
                    ");\r\n\r\n\t\t\t\treorderableList.drawHeaderCallback += DrawHeader;\r\n\t\t\t\treorderableList" +
                    ".drawElementCallback += DrawElement;\r\n\r\n\t\t\t\treorderableList.onAddCallback += Add" +
                    "Item;\r\n\t\t\t\treorderableList.onRemoveCallback += RemoveItem;\r\n\r\n\t\t\t\treorderableLis" +
                    "t.elementHeightCallback += ElementHeightCallback;\r\n\t\t\t}\r\n\r\n\t\t\tprivate void OnDis" +
                    "able()\r\n\t\t\t{\r\n\t\t\t\treorderableList.drawHeaderCallback -= DrawHeader;\r\n\t\t\t\treorder" +
                    "ableList.drawElementCallback -= DrawElement;\r\n\r\n\t\t\t\treorderableList.onAddCallbac" +
                    "k -= AddItem;\r\n\t\t\t\treorderableList.onRemoveCallback -= RemoveItem;\r\n\r\n\t\t\t\treorde" +
                    "rableList.elementHeightCallback -= ElementHeightCallback;\r\n\t\t\t}\r\n\r\n\t\t\tprivate vo" +
                    "id DrawHeader(Rect rect)\r\n\t\t\t{\r\n\t\t\t\tGUI.Label(rect, \"Callbacks invoked when outp" +
                    "ut changes\");\r\n\t\t\t}\r\n\r\n\t\t\tprivate void DrawElement(Rect rect, int index, bool ac" +
                    "tive, bool focused)\r\n\t\t\t{\r\n\t\t\t\tConditionItem item = listExample._cdtList[index];" +
                    "\r\n\t\t\t\tRect newRect = rect;\r\n\r\n\t\t\t\t//var s = serializedObject;\r\n\t\t\t\t//s.Update();" +
                    "\r\n\r\n\t\t\t\tEditorGUI.BeginChangeCheck();\r\n\t\t\t\tnewRect.y += 20;\r\n\t\t\t\tnewRect.x += 18" +
                    ";\r\n\t\t\t\t//item.Test = EditorGUI.TextField(new Rect(rect.x + 18, rect.y, rect.widt" +
                    "h - 18, rect.height), ConditionItem.Outputs[0].Item1);\r\n\r\n\t\t\t\t// Draws the condi" +
                    "tion item selector\r\n\t\t\t\titem.SelectedIndex = EditorGUI.Popup(new Rect(rect.x + 1" +
                    "8, rect.y + 2, rect.width - 18, 20), item.SelectedIndex, ConditionItem.Outputs);" +
                    "\r\n\r\n\t\t\t\tnewRect.y += item.Draw(newRect);\r\n\r\n\t\t\t\t// Draws the callback zone to as" +
                    "sign it\r\n\t\t\t\t//SerializedObject s = new SerializedObject(listExample);\r\n\t\t\t\tvar " +
                    "p = serializedObject.FindProperty(\"_cdtList\").GetArrayElementAtIndex(index);\r\n\t\t" +
                    "\t\t//EditorGUI.PropertyField(new Rect(rect.x + 18, newRect.y + 5, rect.width - 18" +
                    ", 20), p.FindPropertyRelative(\"OnOutputChanged\"));\r\n\t\t\t\t//var p = serializedObje" +
                    "ct.FindProperty(\"OnOutputChanged\");\r\n\t\t\t\t//EditorGUIUtility.LookLikeControls();\r" +
                    "\n\r\n\t\t\t\t//Debug.Log(\"p is => \" + p);\r\n\t\t\t\tvar it = p.serializedObject.GetIterator" +
                    "();\r\n\t\t\t\tp.Next(true);\r\n\t\t\t\tp.Next(false);\r\n\t\t\t\tp.Next(false);\r\n\t\t\t\tEditorGUI.Pr" +
                    "opertyField(new Rect(rect.x + 18, newRect.y + 5, rect.width - 18, 20), p);\r\n\r\n\t\t" +
                    "\t\titem.CallbackCount = item.OnOutputChanged.GetPersistentEventCount();\r\n\t\t\t\t//fo" +
                    "reach (var x in p)\r\n\t\t\t\t//{\r\n\t\t\t\t//\tvar u = x as SerializedProperty;\r\n\t\t\t\t//\tif " +
                    "(u.name == \"size\")\r\n\t\t\t\t//\t{\r\n\t\t\t\t//\t\tDebug.Log(\"found size \" + u.intValue);\r\n\t\t" +
                    "\t\t//\t\titem.CallbackCount = u.intValue;\r\n\t\t\t\t//\t\tRepaint();\r\n\t\t\t\t//\t\tbreak;\r\n\t\t\t\t" +
                    "//\t}\r\n\t\t\t\t//}\r\n\r\n\t\t\t\tif (EditorGUI.EndChangeCheck())\r\n\t\t\t\t{\r\n\t\t\t\t\t//Debug.Log(\"e" +
                    "nd change check true\");\r\n\t\t\t\t\tEditorUtility.SetDirty(target);\r\n\t\t\t\t\t//Debug.Log(" +
                    "\"End change check !\");\r\n\t\t\t\t\tRepaint();\r\n\t\t\t\t}\r\n\t\t\t\t//s.ApplyModifiedPropertiesW" +
                    "ithoutUndo();\r\n\t\t\t}\r\n\r\n\t\t\tprivate void AddItem(ReorderableList list)\r\n\t\t\t{\r\n\t\t\t\t" +
                    "//var item = ScriptableObject.CreateInstance<ConditionItem>();\r\n\t\t\t\tvar item = n" +
                    "ew ConditionItem();\r\n\t\t\t\titem.Initialize();\r\n\t\t\t\tlistExample._cdtList.Add(item);" +
                    "\r\n\r\n\t\t\t\tEditorUtility.SetDirty(target);\r\n\t\t\t}\r\n\r\n\t\t\tprivate void RemoveItem(Reor" +
                    "derableList list)\r\n\t\t\t{\r\n\t\t\t\tlistExample._cdtList.RemoveAt(list.index);\r\n\r\n\t\t\t\tE" +
                    "ditorUtility.SetDirty(target);\r\n\t\t\t}\r\n\t\t\r\n\t\t\tprivate float ElementHeightCallback" +
                    "(int idx)\r\n\t\t\t{\r\n\t\t\t\treturn listExample._cdtList[idx].ItemSize;\r\n\t\t\t}\r\n\r\n\t\t\tpubl" +
                    "ic override void OnInspectorGUI()\r\n\t\t\t{\r\n\t\t\t\tserializedObject.Update();\r\n\t\t\t\tbas" +
                    "e.OnInspectorGUI();\r\n\t\t\t\treorderableList.DoLayoutList();\r\n\t\t\t\tserializedObject.A" +
                    "pplyModifiedPropertiesWithoutUndo();\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\tpublic class EventOutputCha" +
                    "nge : EventArgs\r\n\t\t{\r\n\t\t\tpublic ");
            
            #line 234 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" Invoker;\r\n\t\t\tpublic object Value;\r\n\t\t\tpublic Type ValueType;\r\n\t\t}\r\n\r\n\t\t///<summa" +
                    "ry>\r\n\t\t/// Base behaviour for DNAI IA.\r\n\t\t///</summary>\r\n\t\tpublic class ");
            
            #line 242 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : MonoBehaviour\r\n\t\t{\r\n\t\t\t[HideInInspector]\r\n\t\t\tpublic List<ConditionItem> _cdtLi" +
                    "st = new List<ConditionItem>();// { new ConditionItem() { cdt = new IntCondition" +
                    "() } };\r\n\r\n\t\t\t");
            
            #line 247 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in DataTypes)
			{
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 249 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 250 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"
			//[Serializable]
			//public class UnityEventOutputChange : UnityEvent<EventOutputChange>
			//{
			//}

			///<summary>
			/// Called when output values of the DNAI script change.
			///</summary>
			//public UnityEventOutputChange OnOutputChanged;

			//[Header(""Input variables"")]
			");
            
            #line 263 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Inputs)
			{ 
            
            #line default
            #line hidden
            this.Write("\t\t\t\tpublic ");
            
            #line 265 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t");
            
            #line 266 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t//[Header(\"Output variables\")]\r\n\t\t\t");
            
            #line 269 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Outputs)
			{ 
            
            #line default
            #line hidden
            this.Write("\t\t\t\tprivate ");
            
            #line 271 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[0]));
            
            #line default
            #line hidden
            this.Write(" _");
            
            #line 271 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t\tpublic ");
            
            #line 272 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t{\r\n\t\t\t\t\tget { return _");
            
            #line 274 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write("; }\r\n\t\t\t\t\tprivate set\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\t_");
            
            #line 277 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write(" = value;\r\n\t\t\t\t\t\t//OnOutputChanged.Invoke(new EventOutputChange { Value = value, " +
                    "ValueType = value.GetType(), Invoker = this });\r\n\t\t\t\t\t\t_cdtList.FindAll((x) => x" +
                    ".SelectedOutput == \"");
            
            #line 279 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\").ForEach((y) =>\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\tif (y.Evaluate(value))\r\n\t\t\t\t\t\t\t\ty.OnOutputChan" +
                    "ged?.Invoke(new EventOutputChange { Value = value, ValueType = value.GetType(), " +
                    "Invoker = this });\r\n\t\t\t\t\t\t});\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t");
            
            #line 286 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\tprivate static readonly BinaryManager _manager = new BinaryManager();\r\n\r\n\t\t\t" +
                    "static ");
            
            #line 290 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t\t{\r\n\t\t\t\t//_manager = new BinaryManager();\r\n\t\t\t\t_manager.LoadCommandsFrom(@\"" +
                    "Assets/Standard Assets/DNAI/Scripts/\" + \"");
            
            #line 293 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FilePath));
            
            #line default
            #line hidden
            this.Write("\");\r\n\t\t\t}\r\n\r\n\t\t\t///<summary>\r\n\t\t\t/// Executes the Duly Behaviour by calling the c" +
                    "reated function.\r\n\t\t\t/// Updates Outputs accordingly.\r\n\t\t\t///</summary>\r\n\t\t\t");
            
            #line 300 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var f in Functions)
			{ 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\tpublic void Execute");
            
            #line 303 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t\t\t{\r\n\t\t\t\t\tvar results = new Dictionary<string, dynamic>();\r\n\r\n\t\t\t\t\tresults " +
                    "= _manager.Controller.CallFunction(");
            
            #line 307 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(f.FunctionId));
            
            #line default
            #line hidden
            this.Write(", new Dictionary<string, dynamic>{ ");
            
            #line 307 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(f.FunctionArguments));
            
            #line default
            #line hidden
            this.Write(" });\r\n\t\t\t\t\t");
            
            #line 308 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 if (Outputs.Count > 0)
					{
						foreach (var output in Outputs)
						{
							var varName = output.Split(' ')[1]; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\tif (results.ContainsKey(\"");
            
            #line 313 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("\"))\r\n\t\t\t\t\t\t\t\t");
            
            #line 314 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(" = results[\"");
            
            #line 314 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("\"];\r\n\t\t\t\t\t\t");
            
            #line 315 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 }
					} 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t}\r\n\t\t\t\t\r\n\t\t\t");
            
            #line 319 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\t//}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\Folders\VisualStudio\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"

private string _parameter1Field;

/// <summary>
/// Access the parameter1 parameter of the template.
/// </summary>
private string parameter1
{
    get
    {
        return this._parameter1Field;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool parameter1ValueAcquired = false;
if (this.Session.ContainsKey("parameter1"))
{
    this._parameter1Field = ((string)(this.Session["parameter1"]));
    parameter1ValueAcquired = true;
}
if ((parameter1ValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("parameter1");
    if ((data != null))
    {
        this._parameter1Field = ((string)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class GeneratedCodeTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
