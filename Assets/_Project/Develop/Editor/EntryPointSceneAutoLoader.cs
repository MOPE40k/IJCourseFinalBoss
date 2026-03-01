using UnityEditor;
using UnityEditor.SceneManagement;

namespace Editor
{
    [InitializeOnLoad]
    public class EntryPointSceneAutoLoader
    {
        static EntryPointSceneAutoLoader()
        {
            if (EditorBuildSettings.scenes.Length == 0)
                return;

            string entryPointScenePath = EditorBuildSettings.scenes[0].path;

            SceneAsset entryPointScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(entryPointScenePath);

            EditorSceneManager.playModeStartScene = entryPointScene;
        }
    }
}