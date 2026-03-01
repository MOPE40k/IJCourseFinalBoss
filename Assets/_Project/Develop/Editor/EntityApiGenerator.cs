using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Runtime.Gameplay.EntitiesCore;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class EntityApiGenerator
    {
        // Const
        private const string AssemblyName = "Assembly-CSharp";
        private const string FileFullPath = "_Project/Develop/Runtime/Gameplay/EntitiesCore/Generated/EntityApi.cs";
        private const string ComponentPostfix = "Component";
        private const string PropertyFieldName = "Value";
        private static string OutputPath => Path.Combine(Application.dataPath, FileFullPath);

        [InitializeOnLoadMethod]
        [MenuItem("Tools/Generate EntityAPI")]
        private static void Generate()
        {
            StringBuilder sb = new();

            sb.AppendLine($"namespace {typeof(Entity).Namespace}");
            sb.AppendLine("{");

            sb.AppendLine($"\tpublic partial class {typeof(Entity).Name}");
            sb.AppendLine("\t{");

            Assembly assembly = Assembly.Load(AssemblyName);

            IEnumerable<Type> componentTypes = GetComponentTypesFrom(assembly);

            foreach (Type componentType in componentTypes)
            {
                string typeName = componentType.Name;
                string fullTypeName = componentType.FullName;

                string componentName = RemoveSuffixIfExists(typeName, ComponentPostfix);
                string modifyComponentName = componentName + "C";

                sb.AppendLine($"\t\tpublic {fullTypeName} {modifyComponentName} => this.GetComponent<{fullTypeName}>();");
                sb.AppendLine();

                if (HasSingleField(componentType, out FieldInfo field) && field.Name == PropertyFieldName)
                {
                    sb.AppendLine($"\t\tpublic {GetValidTypeName(field.FieldType)} {componentName} => {modifyComponentName}.{field.Name};");
                    sb.AppendLine();

                    if (HasEmptyConstructor(field.FieldType))
                    {
                        string initializer = "{ " + field.Name + " = new " + GetValidTypeName(field.FieldType) + "() }";

                        sb.AppendLine($"\t\tpublic {typeof(Entity).FullName} Add{componentName}()");
                        sb.AppendLine("\t\t{");
                        sb.AppendLine($"\t\t\treturn this.AddComponent(new {fullTypeName}() {initializer});");
                        sb.AppendLine("\t\t}");
                        sb.AppendLine();
                    }
                }

                string componentParameters = GetParameters(componentType);

                sb.AppendLine($"\t\tpublic {typeof(Entity).FullName} Add{componentName}({componentParameters})");
                sb.AppendLine("\t\t{");
                sb.AppendLine($"\t\t\treturn this.AddComponent(new {fullTypeName}() {GetInitializer(componentType)});");
                sb.AppendLine("\t\t}");
                sb.AppendLine();
            }

            sb.AppendLine("\t}");

            sb.AppendLine("}");

            File.WriteAllText(OutputPath, sb.ToString());

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static bool HasEmptyConstructor(Type type)
            => type.GetConstructor(Type.EmptyTypes) != null
                && type.IsSubclassOf(typeof(UnityEngine.Object)) == false;

        private static IEnumerable<Type> GetComponentTypesFrom(Assembly assembly)
            => assembly
                .GetTypes()
                .Where(type => type.IsInterface == false
                    && type.IsAbstract == false
                    && typeof(IEntityComponent).IsAssignableFrom(type));

        private static string AddPostfixIfMissing(string originalString, string postfix)
        {
            if (originalString.EndsWith(postfix))
            {
                return originalString;
            }

            return originalString + postfix;
        }

        private static bool HasSingleField(Type type, out FieldInfo fieldInfo)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fields.Length != 1)
            {
                fieldInfo = null;

                return false;
            }

            fieldInfo = fields[0];

            return true;
        }

        private static string GetParameters(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fields.Any() == false)
                return string.Empty;

            IEnumerable<string> parameters = fields
                .Select(field => $"{GetValidTypeName(field.FieldType)} {GetVariableNameFrom(field.Name)}");

            return string.Join(", ", parameters);
        }

        private static string GetInitializer(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (fields.Any() == false)
                return string.Empty;

            IEnumerable<string> initializers = fields
                .Select(field => $"{field.Name} = {GetVariableNameFrom(field.Name)}");

            return "{ " + string.Join(", ", initializers) + " }";
        }

        private static string GetVariableNameFrom(string name)
            => char.ToLowerInvariant(name[0]) + name.Substring(1);

        private static string RemoveSuffixIfExists(string originalString, string suffix)
        {
            if (originalString.EndsWith(suffix))
            {
                int suffixStartIndex = originalString.Length - suffix.Length;

                return originalString.Substring(0, suffixStartIndex);
            }

            return originalString;
        }

        public static string GetValidTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                StringBuilder sb = new();

                string fullTypeName = type.FullName;

                int backtickIndex = fullTypeName.IndexOf('`');

                if (backtickIndex >= 0)
                    fullTypeName = fullTypeName.Substring(0, backtickIndex);

                sb.Append(fullTypeName);
                sb.Append('<');

                Type[] genericArgs = type.GetGenericArguments();

                for (int i = 0; i < genericArgs.Length; i++)
                {
                    if (i > 0)
                        sb.Append(", ");

                    sb.Append(GetValidTypeName(genericArgs[i]));
                }

                sb.Append('>');

                return sb.ToString();
            }
            else
            {
                return type.FullName;
            }
        }
    }
}