using UnityEngine;
using Utils.Reactive;

namespace Runtime.Gameplay
{
    public class SequenceGenerationService
    {
        // Runtime
        private ReactiveVeriable<string> _codePhrase = new(string.Empty);
        public IReadOnlyVeriable<string> CodePhrase => _codePhrase;

        public string GetRandomSequence(string chars, int length)
        {
            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                char randomChar = chars[Random.Range(0, chars.Length)];

                result += randomChar;
            }

            _codePhrase.Value = result;

            return result;
        }
    }
}