using BaseCustomFactions.Core;
using BaseCustomFactions.Scripts.Logging;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements
{
	public static class TopBarElementsFinder
	{
		public static (Image allyFlag, Image enemyFlag) GetTopBarElments(GameObject mainCanvas)
		{
			ILog logger = LogFactory.GetLogger(typeof(TopBarElementsFinder), LogLevelsEnum.All);


			Transform gameElementsPanel = mainCanvas.transform.GetChild("Game Elements Panel");

			Transform topInfoBar = gameElementsPanel.GetChild("Top Info Bar");
			logger.Debug($"Top info bar found called: {topInfoBar.name}");

			Transform verticalLayout = topInfoBar.GetChild("Vertical Layout");
			Transform slabContainer = verticalLayout.GetChild("Slab Container");
			Transform container = slabContainer.GetChild("Container");
			Transform horizontalLayout = container.GetChild("Horizontal Layout");

			Transform allyFlagContainer = horizontalLayout.GetChild("Ally Flag Element");
			Transform enemyFlagContainer = horizontalLayout.GetChild("Enemy Flag Element");

			Transform allyFlagImage = allyFlagContainer.GetChild("Ally Flag Image");
			Transform enemyFlagImage = enemyFlagContainer.GetChild("Enemy Flag Image");

			Image allyFlagImageComponent = allyFlagImage.GetComponent<Image>();
			Image enemyFlagImageComponent = enemyFlagImage.GetComponent<Image>();

			return (allyFlagImageComponent, enemyFlagImageComponent);
		}
	}
}
