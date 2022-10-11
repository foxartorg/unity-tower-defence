using System;
using UnityEngine;

namespace App.Tower {
	public class TowerBuilder : MonoBehaviour {
		public static TowerBuilder Instance;
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

		public GameObject CreateTower() {
			return towerGameObject;
		}
	}
}
