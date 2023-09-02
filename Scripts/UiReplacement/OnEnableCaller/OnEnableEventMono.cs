using System;
using UnityEngine;

namespace Assets.BaseCustomFactionMod.Scripts.UiReplacement.OnEnableCaller
{
	public class OnEnableEventMono : MonoBehaviour
	{
		public event Action<GameObject> OnEnableEvent;

		public void OnEnable()
		{
			OnEnableEvent?.Invoke(this.gameObject);
		}
	}
}
