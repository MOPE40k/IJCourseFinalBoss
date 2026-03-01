using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace Editor
{
    public class LayerMasksAPIGenerator
    {
        // Consts
        private const int LastLayerMaskIndex = 31;
        private const string GenerateClassName = "UnityLayers";
        private const string FilePath = "_Project/Develop/Runtime/Gameplay/EntitiesCore/Generated";
        private const string FileName = "LayerMasksApi.cs";
        private static string OutputPath => Path.Combine(Application.dataPath, FilePath, FileName);

        [InitializeOnLoadMethod]
        [MenuItem("Tools/Generate LayerMasksAPI")]
        private static void Generate()
        {
            StringBuilder sb = new();

            sb.AppendLine($"using {typeof(LayerMask).Namespace};");
            sb.AppendLine();

            sb.AppendLine($"namespace {typeof(LayerMasksAPIGenerator).Namespace}");
            sb.AppendLine("{");

            sb.AppendLine($"\tpublic static class {GenerateClassName}");
            sb.AppendLine("\t{");

            List<string> layerNames = GetAllLayerNames();

            foreach (string layerName in layerNames)
                sb.AppendLine($"\t\tpublic static readonly int Layer{RemoveSpaceFrom(layerName)} = LayerMask.NameToLayer(\"{layerName}\");");

            sb.AppendLine();

            foreach (string layerName in layerNames)
                sb.AppendLine($"\t\tpublic static readonly int LayerMask{RemoveSpaceFrom(layerName)} = 1 << Layer{RemoveSpaceFrom(layerName)};");

            sb.AppendLine("\t}");

            sb.AppendLine("}");

            File.WriteAllText(OutputPath, sb.ToString());

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static List<string> GetAllLayerNames()
        {
            List<string> allNames = new();

            for (int i = 0; i < LastLayerMaskIndex; i++)
            {
                string layerName = LayerMask.LayerToName(i);

                if (layerName != string.Empty)
                    allNames.Add(layerName);
            }

            return allNames;
        }

        private static string RemoveSpaceFrom(string layerName)
            => layerName.Replace(" ", "");
    }
}