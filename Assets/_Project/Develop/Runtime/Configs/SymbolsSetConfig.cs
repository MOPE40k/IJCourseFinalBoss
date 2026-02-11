using UnityEngine;

namespace Runtime.Configs
{
    public abstract class SymbolsSetConfig : ScriptableObject, ISymbolsSetConfig
    {
        [Header("Settings:")]
        [SerializeField] private string _symbolsSet = "TestSet";
        [SerializeField, Min(1)] private int _phraseLength = 5;

        // Runtime
        public string SymbolsSet => _symbolsSet;
        public int PhraseLength => _phraseLength;

        private void OnValidate()
            => InputCheck();

        private void InputCheck()
        {
            if (string.IsNullOrEmpty(_symbolsSet))
                return;

            string filtered = SymbolsCheck(_symbolsSet);

            if (filtered.Length > _phraseLength)
                filtered = filtered.Substring(0, _phraseLength);

            filtered.Replace(" ", "");

            if (filtered != _symbolsSet)
                _symbolsSet = filtered;
        }

        protected abstract string SymbolsCheck(string originalInput);
    }
}