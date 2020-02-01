using System;
using UnityEngine;

namespace GGJ2020 {
	public class LevelPortal : MonoBehaviour {
		private const string PlayerTag = "Player";

		[SerializeField] private GameRuntime gameRuntime;

		#region Unity Messages
		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.tag == PlayerTag) {
				ILevelSystem levelSystem = gameRuntime.Locator.Resolve<ILevelSystem>();
				int l = levelSystem.CurrentLevel;
				levelSystem.GoToLevel(l + 1);
			}
		}
		#endregion
	}
}