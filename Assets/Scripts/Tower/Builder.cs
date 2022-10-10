using System;
using UnityEngine;

namespace Tower {
	public class Builder : MonoBehaviour {
		public static Builder Instance;
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
