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


        //New update
        [Tooltip("Background flag used for end of round. Fluttering flag")]
        public Sprite endOfRoundScreenImage;
        [Tooltip("Crest used for the faction")]
        public Sprite factionCrest;
        [Tooltip("Emblem used for the faction. This is crest + flag + name used for seleciton and scoreboard")]
        public Sprite factionEmblem;
        [Tooltip("Background for faction selection")]
        public Sprite factionBackgroundSelection;
        [Tooltip("Sprite used for round info bar (topbar)")]
        public Sprite factionTopImage;
        [Tooltip("Used for map voting")]
        public Sprite factionMapVotingImage;

		[Tooltip("Material used for the faction flag replacement")]
		public Texture2D flagReplacementImage;

	}
}