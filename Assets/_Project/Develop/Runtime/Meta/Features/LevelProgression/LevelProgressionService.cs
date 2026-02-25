using System.Collections.Generic;
using Runtime.Utils.DataManagement.DataProviders;
using Utils.DataManagement;

namespace Runtime.Meta.Features.LevelProgression
{
    public class LevelProgressionService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        // Consts
        private const int FirstLevel = 1;

        public LevelProgressionService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterReader(this);
            playerDataProvider.RegisterWriter(this);
        }

        // Runtime
        private readonly List<int> _completedLevels = new();

        public bool IsLevelCompleted(int levelNumber)
            => _completedLevels.Contains(levelNumber);

        public void AddLevelToCompleted(int levelNumber)
        {
            if (IsLevelCompleted(levelNumber))
                return;

            _completedLevels.Add(levelNumber);
        }

        public bool CanPlay(int levelNumber)
            => IsFirstLevel(levelNumber) || PreviousLevelCompleted(levelNumber);

        private bool PreviousLevelCompleted(int levelNumber)
            => IsLevelCompleted(levelNumber - 1);

        private bool IsFirstLevel(int levelNumber)
            => levelNumber == FirstLevel;

        public void WriteTo(PlayerData data)
        {
            data.CompletedLevels.Clear();
            data.CompletedLevels.AddRange(_completedLevels);
        }

        public void ReadFrom(PlayerData data)
        {
            _completedLevels.Clear();
            _completedLevels.AddRange(data.CompletedLevels);
        }
    }
}