using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ2020 {
	/// <summary>
	/// Basic level system that relies on scenes to be ordered in the build settings exactly one after another.
	/// </summary>
	[CreateAssetMenu]
	public class BasicLevelSystem : ScriptableObject, ILevelSystem {
		[SerializeField] private int firstLevel = 1;
		[SerializeField] private GameEvent onLevelChanged;

		public int CurrentLevel {
			get {
				int level = SceneManager.GetActiveScene().buildIndex - firstLevel + 1;
				if (level < 1)
					return -1;
				return level;
			}
		}

		public GameEvent OnLevelChanged => onLevelChanged;

		public void GoToLevel(int level) {
			AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
			int nextLevel = level - firstLevel + 1;
			AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevel, LoadSceneMode.Additive);
			operation.completed += (AsyncOperation a) => {
				SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(nextLevel));
				if (onLevelChanged != null)
					onLevelChanged.Raise();
			};
		}

	}
}