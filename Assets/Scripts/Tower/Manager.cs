using System;
using UnityEngine;

namespace Tower {
	public class Manager : MonoBehaviour {
		public static Manager Instance;
		[SerializeField] public GameObject towerGameObject;

		private void Awake() {
			CheckInstance();
		}

		private void CheckInstance() {
			if (Instance != null) {
				throw new Exception("Multiple instances");
			}

			Instance = this;
		}

		public GameObject GetTowerToBuild() {
			return towerGameObject;
		}
	}
}
