using UnityEngine;

namespace Tower {
	public class BuildManager : MonoBehaviour {
		public static BuildManager Instance;
		[SerializeField] public GameObject towerPrefab;
		private GameObject _towerToBuild;

		private void Awake() {
			if (Instance != null) {
				Debug.LogError("More than one BuildManager in scene");
				return;
			}

			Instance = this;
		}

		private void Start() {
			_towerToBuild = towerPrefab;
		}

		public GameObject GetTowerToBuild() {
			return _towerToBuild;
		}
	}
}
