using UnityEngine;

namespace GGJ2020 {
	[CreateAssetMenu]
	public class GameRuntime : ScriptableObject {
		[SerializeField] private ScriptableServiceLocator locator;

		public IServiceLocator Locator => locator;
	}
}