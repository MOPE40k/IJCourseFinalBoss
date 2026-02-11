using UnityEngine;
using Utils;

namespace Runtime.Gameplay
{
    public class SequanceGenerationService : IService
    {
        public string GetRandomSequance(string chars, int length)
        {
            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                char randomChar = chars[Random.Range(0, chars.Length)];

                result += randomChar;
            }

            return result;
        }
    }
}