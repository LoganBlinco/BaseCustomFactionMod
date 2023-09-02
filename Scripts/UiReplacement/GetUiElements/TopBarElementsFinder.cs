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


			Transform gameElementsPanel = mainCanvas.transform.GetChild(4);

			Transform topInfoBar = gameElementsPanel.GetChild(6);
			logger.Debug($"Top info bar found called: {topInfoBar.name}");

			Transform verticalLayout = topInfoBar.GetChild(0);
			Transform slabContainer = verticalLayout.GetChild(0);
			Transform container = slabContainer.GetChild(0);
			Transform horizontalLayout = container.GetChild(1);

			Transform allyFlagContainer = horizontalLayout.GetChild(2);
			Transform enemyFlagContainer = horizontalLayout.GetChild(5);

			Transform allyFlagImage = allyFlagContainer.GetChild(2);
			Transform enemyFlagImage = enemyFlagContainer.GetChild(2);

			Image allyFlagImageComponent = allyFlagImage.GetComponent<Image>();
			Image enemyFlagImageComponent = enemyFlagImage.GetComponent<Image>();

			return (allyFlagImageComponent, enemyFlagImageComponent);
		}
	}
}
