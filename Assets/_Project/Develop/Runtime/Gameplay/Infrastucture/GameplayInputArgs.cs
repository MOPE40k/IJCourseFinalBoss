using Runtime.Configs;
using Runtime.Utils.SceneManagement;

namespace Runtime.Gameplay.Infrastucture
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        // References
        public ISymbolsSetConfig CharsConfig { get; private set; } = null;

        public GameplayInputArgs(ISymbolsSetConfig charsConfig)
            => CharsConfig = charsConfig;
    }
}