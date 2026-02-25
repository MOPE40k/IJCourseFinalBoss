using Runtime.Configs.Gameplay.Gamemodes;
using Runtime.Utils.SceneManagement;

namespace Runtime.Gameplay.Infrastucture
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        // References
        public ISymbolsSetConfig CharsConfig { get; private set; } = null;
        public int LevelNumber = 0;
        public GameplayInputArgs(ISymbolsSetConfig charsConfig, int levelNumber = 0)
        {
            CharsConfig = charsConfig;
            LevelNumber = levelNumber;
        }
    }
}