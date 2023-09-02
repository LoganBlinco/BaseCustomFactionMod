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


		Transform endOfMatchPanel = MainCanvas.transform.GetChild(2);

		Transform endOfMatchFinalPanel = endOfMatchPanel.GetChild(0);

		Transform verticalLayout = endOfMatchFinalPanel.GetChild(4);
		Transform scoreContainer = verticalLayout.GetChild(1);

		Transform leftSide = scoreContainer.GetChild(0);
		Transform rightSide = scoreContainer.GetChild(2);
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
		Transform headerFactionContainer = leftSide.GetChild(0);
		Transform emblemBackground = headerFactionContainer.GetChild(0);

		Transform emblem = headerFactionContainer.GetChild(3);
		Transform factionTextTransform = headerFactionContainer.GetChild(5);

		Image attackingBackground =  emblemBackground.GetComponent<Image>();
		Image attackingEmblem = emblem.GetComponent<Image>();
		TextMeshProUGUI factionText = factionTextTransform.GetComponent<TextMeshProUGUI>();
		ILog logger = LogFactory.GetLogger(typeof(RoundEndPanelFinder));
		logger.Debug($"Returning: {attackingBackground.name} {attackingEmblem.name} {factionText.name}");
		return (attackingBackground, attackingEmblem, factionText);
	}


	public static (TextMeshProUGUI factionText, Image factionEmblem, TextMeshProUGUI roundEndReasonText) GetFactionWinPopup(GameObject MainCanvas)
	{
		Transform RoundEndPanel = MainCanvas.transform.GetChild(14);
		Transform factionRoundWinnerPanel = RoundEndPanel.GetChild(0);

		Transform factionWinningText = factionRoundWinnerPanel.GetChild(1);
		Transform winningFactionEmblem = factionRoundWinnerPanel.GetChild(4);

		Transform verticalLayout = factionRoundWinnerPanel.GetChild(2);
		Transform roundnEndReason = verticalLayout.GetChild(1);


		TextMeshProUGUI factionText = factionWinningText.GetComponent<TextMeshProUGUI>();
		Image emblem = winningFactionEmblem.GetComponent<Image>();
		TextMeshProUGUI roundEndReasonText = roundnEndReason.GetComponent<TextMeshProUGUI>();

		return (factionText, emblem, roundEndReasonText);
	}

}
