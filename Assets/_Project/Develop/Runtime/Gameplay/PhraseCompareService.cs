using Utils;

namespace Runtime.Gameplay
{
    public class PhraseCompareService : IService
    {
        public bool Compare(string userInput, string codePhrase)
            => userInput.Equals(codePhrase);
    }
}