using Utils;

namespace Runtime.Gameplay
{
    public class PhraseCompareService
    {
        public bool Compare(string userInput, string codePhrase)
            => userInput.Equals(codePhrase);
    }
}