using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ2020 {
	public class SceneLoader : MonoBehaviour {
		[SerializeField] private int sceneBuildIndex = 0;
		[SerializeField] private LoadSceneMode loadSceneMode;
		[SerializeField] private bool setAsActive = true;

		#region Unity Messages
		private void Awake() {
			if (!SceneManager.GetSceneByBuildIndex(sceneBuildIndex).IsValid()) {
				AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneBuildIndex, loadSceneMode);
				if (setAsActive) {
					loadOperation.completed += (AsyncOperation a) => {
						Scene s = SceneManager.GetSceneByBuildIndex(sceneBuildIndex);
						SceneManager.SetActiveScene(s);
					};
				}
			}
		}
		#endregion
	}
}