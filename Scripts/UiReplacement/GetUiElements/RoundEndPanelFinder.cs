using BaseCustomFactions.Core;
using BaseCustomFactions.Scripts.Logging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class RoundEndPanelFinder 
{

	public static (Image attackingBackground,
		Image attackingEmblem,
		TextMeshProUGUI attackingText,
		Image defendingBackground,
		Image defendingEmblem,
		TextMeshProUGUI defendingText)
		GetElements(GameObject MainCanvas)
	{
		ILog logger = LogFactory.GetLogger(typeof(RoundEndPanelFinder));


		Transform endOfMatchPanel = MainCanvas.transform.GetChild("End of Match Panel");
		Transform endOfMatchFinalPanel = endOfMatchPanel.GetChild("End of Match Final Panel");

		Transform verticalLayout = endOfMatchFinalPanel.GetChild("Vertical Layout");
		Transform scoreContainer = verticalLayout.GetChild("Score Container");

		Transform leftSide = scoreContainer.GetChild("Left Side");
		Transform rightSide = scoreContainer.GetChild("Right Side");
		logger.Debug($"left side of round end: {leftSide.name}");
		logger.Debug($"right side of round end: {rightSide.name}");

		(Image attackingBackground, Image attackingEmblem, TextMeshProUGUI attackingText) = GetInfoFromSide(leftSide);
		(Image defendingBackground, Image defendingEmblem, TextMeshProUGUI defendingText) = GetInfoFromSide(rightSide);

		return (attackingBackground,
			attackingEmblem,
			attackingText,
			defendingBackground,
			defendingEmblem,
			defendingText);
	}

	private static (Image backgroundImage, Image emblemImage, TextMeshProUGUI factionText) GetInfoFromSide(Transform leftSide)
	{
		Transform headerFactionContainer = leftSide.GetChild("Header Faction Container");
		Transform emblemBackground = headerFactionContainer.GetChild("Emblem Background");

		Transform emblem = headerFactionContainer.GetChild("Emblem");
		Transform factionTextTransform = headerFactionContainer.GetChild("Faction Name");

		Image attackingBackground =  emblemBackground.GetComponent<Image>();
		Image attackingEmblem = emblem.GetComponent<Image>();
		TextMeshProUGUI factionText = factionTextTransform.GetComponent<TextMeshProUGUI>();
		ILog logger = LogFactory.GetLogger(typeof(RoundEndPanelFinder));
		logger.Debug($"Returning: {attackingBackground.name} {attackingEmblem.name} {factionText.name}");
		return (attackingBackground, attackingEmblem, factionText);
	}


	public static (TextMeshProUGUI factionText, Image factionEmblem, TextMeshProUGUI roundEndReasonText) GetFactionWinPopup(GameObject MainCanvas)
	{
		Transform RoundEndPanel = MainCanvas.transform.GetChild("Round End Panel");
		Transform factionRoundWinnerPanel = RoundEndPanel.GetChild("Faction Round Winner Panel");

		Transform factionWinningText = factionRoundWinnerPanel.GetChild("Faction Winner Text");
		Transform winningFactionEmblem = factionRoundWinnerPanel.GetChild("Winning Faction Emblem Image");

		Transform verticalLayout = factionRoundWinnerPanel.GetChild("Vertical Layout");
		Transform roundEndReason = verticalLayout.GetChild("Round End Reason Text");


		TextMeshProUGUI factionText = factionWinningText.GetComponent<TextMeshProUGUI>();
		Image emblem = winningFactionEmblem.GetComponent<Image>();
		TextMeshProUGUI roundEndReasonText = roundEndReason.GetComponent<TextMeshProUGUI>();

		return (factionText, emblem, roundEndReasonText);
	}

}
