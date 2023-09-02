using Assets.BaseCustomFactionMod.Scripts.UiReplacement.GetUiElements;
using Assets.BaseCustomFactionMod.Scripts.UiReplacement.OnEnableCaller;
using BaseCustomFactions.Core;
using HoldfastSharedMethods;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.PanelObjects
{
	public class SpawnMenuObjects
	{
		private readonly Image image_factionEmblem;
		private readonly TextMeshProUGUI text_factionName;

		private FactionCountry _attackingFaction;
		private FactionCountry _defendingFaction;
		private FactionUIOverride _attackerOverride;
		private FactionUIOverride _defenderOverride;

		private OnEnableEventMono _enableCaller;
		private GameObject _flagObject;

		public SpawnMenuObjects(Image factionEmblem, TextMeshProUGUI factionName, FactionCountry attackingFaction, FactionCountry defendingFaction,
			GameObject flagObject)
		{
			image_factionEmblem = factionEmblem;
			text_factionName = factionName;

			_attackingFaction = attackingFaction;
			_defendingFaction = defendingFaction;
			_flagObject = flagObject;

			_enableCaller = image_factionEmblem.gameObject.AddComponent<OnEnableEventMono>();
			_enableCaller.OnEnableEvent += HeaderEmblemEnabled;
		}

		public void SetUpReferences(FactionUIOverride attackerOverride,
			FactionUIOverride defenderOverride)
		{
			_attackerOverride = attackerOverride;
			_defenderOverride = defenderOverride;
		}

		public void HeaderEmblemEnabled(GameObject emblemObject)
		{
			HeaderEmblemEnabledAsnc();
		}

		private async void HeaderEmblemEnabledAsnc()
		{
			await Task.Delay(100);
			FactionCountry factionCountry = GetFactionFromString.GetFactionBasedOnContainingName(image_factionEmblem.sprite.name);
			if (factionCountry == _attackingFaction && _attackerOverride != null)
			{
				image_factionEmblem.overrideSprite = _attackerOverride.selectClassHeaderEmblem;
				text_factionName.text = $"{_attackerOverride.customNameToUse}";
				ApplyFlagChange(factionCountry, _attackerOverride.flagReplacementImage);
			}
			else if (factionCountry == _defendingFaction && _defenderOverride != null)
			{
				image_factionEmblem.overrideSprite = _defenderOverride.selectClassHeaderEmblem;
				text_factionName.text = $"{_defenderOverride.customNameToUse}";
				ApplyFlagChange(factionCountry, _defenderOverride.flagReplacementImage);
			}
		}


		private bool ApplyFlagChange(FactionCountry factionCountry, Texture2D material)
		{
			if (_flagObject == null) {
				_flagObject = SpawnMenuCharacterSceneFinder.GetObjects();
			}
			if (_flagObject == null)
			{
				Debug.LogError($"Tried to change, but we are null still :( ");
				_flagObject = SpawnMenuCharacterSceneFinder.GetObjectsAlt();
				if (_flagObject == null)
				{
					Debug.LogError("the alt system also failed.");
					return false;
				}
				else
				{
					Debug.LogError("ALT SYSTEM WORKED OMFG");
				}
			}


			if (material == null) { return false; }
			//Debug.Log("apply change ran");
			Transform flagTransform = _flagObject.transform.Find("Flag");
			Material flagMaterial;
			if (flagTransform == null)
			{
				Transform factionFlag = _flagObject.transform.GetChild(0);
				Transform flag = factionFlag.GetChild(0);
				flagMaterial = flag.gameObject.GetComponent<Renderer>().material;
			}
			else
			{
				flagMaterial = flagTransform.gameObject.GetComponent<Renderer>().material;
			}

			if (flagMaterial == null)
			{
				Debug.LogError("flag material is null :((((");
			}

			FactionCountry materialFaction = GetFactionFromString.GetFactionBasedOnContainingName(flagMaterial.name);
			if (materialFaction == factionCountry)
			{
				ChangeMaterial(material, flagMaterial);
				return true;
			}
			//Debug.LogError("not the right material faction");
			return false;
		}

		public static Vector2 offset = new Vector2(1.7f, -1.3f);
		public static Vector2 scale = new Vector2(-3.5f, 4.2f);

		private static void ChangeMaterial(Texture material, Material flagMaterial)
		{
			flagMaterial.SetTexture("_MainTex", material);
			flagMaterial.mainTextureOffset = offset;
			flagMaterial.mainTextureScale = scale;
			Debug.Log($"applying material to mat called: {flagMaterial.name}");
		}
	}
}
