using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/New LevelsListConfig", fileName = "LevelsListConfig")]

    public class LevelsListConfig : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levels = null;

        public IReadOnlyList<LevelConfig> Levels => _levels;

        public LevelConfig GetBy(int levelNumber)
        {
            int levelIndex = levelNumber - 1;

            return _levels[levelIndex];
        }
    }
}