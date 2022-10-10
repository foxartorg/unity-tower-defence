using UnityEngine;

namespace Tower {
	public class Manager : MonoBehaviour {
		public static Manager Instance;
		[SerializeField] public GameObject towerPrefab;

		private void Awake() {
			if (Instance != null) {
				Debug.LogError("More than one BuildManager in scene");
				return;
			}

			Instance = this;
		}

		public GameObject GetTowerToBuild() {
			return towerPrefab;
		}
	}
}
