using System;
using UnityEngine;
using UnityEngine.Events;

namespace GGJ2020 {
	public sealed class GameEventListener : MonoBehaviour {
		[Serializable]
		private struct GameEventResponse {
#pragma warning disable 0649
			[SerializeField] private GameEvent @event;
			[SerializeField] private UnityEvent response;
#pragma warning restore 0649

			public GameEvent Event => @event;
			public UnityEvent Response => response;
		}
#pragma warning disable 0649
		[SerializeField] private GameEventResponse[] pairs;
#pragma warning restore 0649

		public void OnEnable() {
			for (int i = 0; i < pairs.Length; i++)
				pairs[i].Event.RegisterListener(this);
		}

		public void OnDisable() {
			for (int i = 0; i < pairs.Length; i++)
				pairs[i].Event.UnregisterListener(this);
		}

		private int IndexOf(GameEvent e) {
			for (int i = 0; i < pairs.Length; i++)
				if (pairs[i].Event == e)
					return i;
			return -1;
		}

		public void OnEventRaised(GameEvent e) {
			if (e == null)
				throw new ArgumentNullException("e");
			int index = IndexOf(e);
			if (index < 0) {
				Debug.LogWarning("Failed to find event in " + GetType().Name + ".");
				return;
			}
			pairs[index].Response.Invoke();
		}
	}
}