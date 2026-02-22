using UnityEngine;

namespace Runtime.Gameplay
{
    public class SequenceGenerationService
    {
        public string GetRandomSequence(string chars, int length)
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