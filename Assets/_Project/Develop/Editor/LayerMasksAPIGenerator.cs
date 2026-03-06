using System.Text;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace Editor
{
    public class LayerMasksApiGenerator
    {
        // Consts
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

            sb.AppendLine($"namespace {typeof(LayerMasksApiGenerator).Namespace}");
            sb.AppendLine("{");

            sb.AppendLine($"\tpublic static class {GenerateClassName}");
            sb.AppendLine("\t{");

            string[] layersMasks = UnityEditorInternal.InternalEditorUtility.layers;

            foreach (string layerName in layersMasks)
                sb.AppendLine($"\t\tpublic static readonly int Layer{RemoveSpaceFrom(layerName)} = LayerMask.NameToLayer(\"{layerName}\");");

            sb.AppendLine();

            foreach (string layerName in layersMasks)
                sb.AppendLine($"\t\tpublic static readonly int LayerMask{RemoveSpaceFrom(layerName)} = 1 << Layer{RemoveSpaceFrom(layerName)};");

            sb.AppendLine("\t}");

            sb.AppendLine("}");

            File.WriteAllText(OutputPath, sb.ToString());

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static string RemoveSpaceFrom(string layerName)
            => layerName.Replace(" ", "");
    }
}