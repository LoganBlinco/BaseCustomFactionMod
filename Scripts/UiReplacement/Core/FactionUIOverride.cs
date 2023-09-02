using UnityEngine;

namespace BaseCustomFactions.Core
{
    [System.Serializable]
    public class FactionUIOverride
    {
        [Tooltip("Name overided which is shown in the scoreboard ")]
        public string customNameToUse;
        [Tooltip("This is the name used when describing the faction. For example the 'British' are victorious, not the 'Britain' are victorious")] 
        public string customNameAdjective;
        [Tooltip("Sprite used for the faction next to the ticket counter and round timer")]
        public Sprite topBarSprite;
        [Tooltip("Sprite used for the scoreboard")]
        public Sprite scoreboardSprite;
        [Tooltip("Sprite used for players who are spawned in -- top left where the ammo count is")]
        public Sprite playerInfoIconSprite;
        [Tooltip("Sprite used for the faction selection screen")]
        public Sprite factionSelectionSprite;
        [Tooltip("Sprite used for the faction selection screen when a faction cannot be joined (eg full)")]
        public Sprite factionSelectionDisabledSprite;
        [Tooltip("Sprite used for the round end sprite. This is the square one..")]
        public Sprite squareRoundEndBoardSprite;
        [Tooltip("Sprite used for the class selection header")]
        public Sprite selectClassHeaderEmblem;
        [Tooltip("Material used for the faction flag replacement")]
        public Texture2D flagReplacementImage;
        
        [Tooltip("Sprite ")]
        public Sprite mapVotingSprite;
    }
}