using System;
using UnityEngine;

namespace GGJ2020 {
	public class LevelPortal : MonoBehaviour {
		private const string PlayerTag = "Player";

		[SerializeField] private GameRuntime gameRuntime;
		//[SerializeField] private PrincessStats Pstat;
		
		#region Unity Messages
		private void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.tag == PlayerTag && PrincessStats.allKeyFrags) {
				ILevelSystem levelSystem = gameRuntime.Locator.Resolve<ILevelSystem>();
				int l = levelSystem.CurrentLevel;
				//Pstat.Restart();
				levelSystem.GoToLevel(l + 1);
			}
		}
		#endregion
	}
}