using UnityEngine;

namespace GGJ2020 {
	public class PersistentObject : MonoBehaviour {
		[SerializeField] private PersistentObjectSet set;

		#region Unity Messages
		private void OnEnable() {
			set.Add(this);
		}

		private void OnDisable() {
			set.Remove(this);
		}
		#endregion
	}
}