using Runtime.Configs.Gameplay.Gamemodes;
using Runtime.Utils.SceneManagement;

namespace Runtime.Gameplay.Infrastucture
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        // References
        //public ISymbolsSetConfig CharsConfig { get; private set; } = null;
        public int LevelNumber = 0;

        public GameplayInputArgs(int levelNumber)
            => LevelNumber = levelNumber;
        // public GameplayInputArgs(ISymbolsSetConfig charsConfig)
        //     => CharsConfig = charsConfig;
    }
}