using System.Linq;
using UnityEngine;

namespace Runtime.Configs.Gameplay.Gamemodes
{
    [CreateAssetMenu(menuName = "Configs/New DigitsSetConfig", fileName = "DigitsSetConfig")]
    public class DigitsSetConfig : SymbolsSetConfig
    {
        protected override string SymbolsCheck(string originalString)
            => new string(originalString.Where(char.IsDigit).ToArray());
    }
}