using System;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2020 {
	[CreateAssetMenu]
	public sealed class GameEvent : ScriptableObject {
		private List<GameEventListener> listeners = new List<GameEventListener>(4);

		public void Raise() {
			for (int i = listeners.Count - 1; i >= 0; i--) {
				if (listeners[i] != null)
					listeners[i].OnEventRaised(this);
			}
		}

		public void RegisterListener(GameEventListener listener) {
			listeners.Add(listener);
		}

		public void UnregisterListener(GameEventListener listener) {
			listeners.Remove(listener);
		}
	}
}