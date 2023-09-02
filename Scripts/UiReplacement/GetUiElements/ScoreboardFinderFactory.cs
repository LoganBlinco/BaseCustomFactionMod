using BaseCustomFactions.Scripts.Logging;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements
{
	public static class ScoreboardFinderFactory
	{
		public static (Image attacker, Image defender) GetEmblems()
		{
			ILog logger = LogFactory.GetLogger(typeof(ScoreboardFinderFactory), LogLevelsEnum.All);

			GameObject scoreboardPanel = GameObject.Find("New Scoreboard Panel");
			if (scoreboardPanel == null)
			{
				logger.LogError($"Scoreboard panel is null");
				return (null, null);
			}
			Transform scoreboardContainer = scoreboardPanel.transform.GetChild(1);
			Transform horizontalLayout = scoreboardContainer.transform.GetChild(5);
			logger.Debug($"Horizontal layout group is called: {horizontalLayout}");

			//attacking faction
			Transform attackingFaction = horizontalLayout.GetChild(0);
			Transform attackerImageTransform = attackingFaction.GetChild(1);

			Image attackerImage = attackerImageTransform.gameObject.GetComponent<Image>();
			if (attackerImage == null)
			{
				logger.LogError($"Attacking image for scoreboard is null");
			}

			//defending faction
			Transform defendingFaction = horizontalLayout.GetChild(1);
			Transform defenderImageTransform = defendingFaction.GetChild(1);

			Image defenderImage = defenderImageTransform.gameObject.GetComponent<Image>();
			if (defenderImage == null)
			{
				logger.LogError($"defender image for scoreboard is null");
			}
			
			return (attackerImage, defenderImage);
		}
	}
}
