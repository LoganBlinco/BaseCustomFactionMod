using BaseCustomFactions.Core;

namespace BaseCustomFactions
{
    public class MapVotingObjects
    {
        private readonly MapVotingCard[] _mapVotingCards;

        public MapVotingObjects(MapVotingCard[] mapVotingCards)
        {
            _mapVotingCards = mapVotingCards;
        }

        public void Replace(CustomFactionSettingsManager settingsManager)
        {
            foreach (MapVotingCard workingCard in _mapVotingCards)
            {
                workingCard.Replace(settingsManager);
            }
        }

        public void Destroy()
        {
            foreach (MapVotingCard workingCard in _mapVotingCards)
            {
                workingCard.Destroy();
            }
        }
    }
}