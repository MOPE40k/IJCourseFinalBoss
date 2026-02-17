using System.Linq;
using UnityEngine;

namespace Runtime.Configs.Gameplay.Gamemodes
{
    [CreateAssetMenu(menuName = "Configs/New LettersSetConfig", fileName = "LettersSetConfig")]
    public class LettersSetConfig : SymbolsSetConfig
    {
        protected override string SymbolsCheck(string originalString)
            => new string(originalString.Where(char.IsLetter).ToArray());
    }
}