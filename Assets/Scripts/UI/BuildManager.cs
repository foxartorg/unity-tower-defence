using UnityEngine;

namespace UI {
	public class BuildManager : MonoBehaviour {
		private static BuildManager _instance;
		public GameObject towerPrefab;
		private GameObject _towerToBuild;

		private void Awake() {
			if (_instance != null) {
				Debug.LogError("More than one BuildManager in scene");
				return;
			}

			_instance = this;
		}

		private void Start() {
			_towerToBuild = towerPrefab;
		}

		public GameObject GetTowerToBuild() {
			return _towerToBuild;
		}
	}
}
