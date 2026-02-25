using System.Collections.Generic;
using System.Linq;
using Runtime.Utils.DataManagement.DataProviders;
using Utils.DataManagement;
using Utils.Reactive;

namespace Runtime.Meta.Features.Sessions
{
    public class SessionsResultsCounterService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        // Runtime
        private readonly Dictionary<SessionEndConditionTypes, ReactiveVeriable<int>> _sessionsResults = null;

        public SessionsResultsCounterService(
            Dictionary<SessionEndConditionTypes, ReactiveVeriable<int>> sessionsResults,
            PlayerDataProvider playerDataProvider)
        {
            _sessionsResults = new Dictionary<SessionEndConditionTypes, ReactiveVeriable<int>>(sessionsResults);

            playerDataProvider.RegisterReader(this);
            playerDataProvider.RegisterWriter(this);
        }

        // Runtime
        public SessionEndConditionTypes[] AvailableSessionEndConditions => _sessionsResults.Keys.ToArray();

        public IReadOnlyVeriable<int> GetCondition(SessionEndConditionTypes type)
            => _sessionsResults[type];

        public void Add(SessionEndConditionTypes type)
            => _sessionsResults[type].Value++;

        public void Reset()
        {
            foreach (KeyValuePair<SessionEndConditionTypes, ReactiveVeriable<int>> pair in _sessionsResults)
                pair.Value.Value = 0;
        }

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<SessionEndConditionTypes, int> sessionResult in data.SessionsResultsData)
                if (_sessionsResults.ContainsKey(sessionResult.Key))
                    _sessionsResults[sessionResult.Key].Value = sessionResult.Value;
                else
                    _sessionsResults.Add(sessionResult.Key, new ReactiveVeriable<int>(sessionResult.Value));
        }

        public void WriteTo(PlayerData data)
        {
            foreach (KeyValuePair<SessionEndConditionTypes, ReactiveVeriable<int>> sessionResult in _sessionsResults)
                if (data.SessionsResultsData.ContainsKey(sessionResult.Key))
                    data.SessionsResultsData[sessionResult.Key] = sessionResult.Value.Value;
                else
                    data.SessionsResultsData.Add(sessionResult.Key, sessionResult.Value.Value);
        }
    }
}