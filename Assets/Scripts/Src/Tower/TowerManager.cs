using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Tower {
	public sealed class TowerManager : MonoInstance<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		[SerializeField] public GameObject towerCanvas;
		public List<GameObject> towers;
		private int _counter;

		public GameObject CreateTower(GameObject platform) {
			if (!this.CheckTower()) {
			}
			
			var instantiate= Instantiate(this.towerPrefab, this.GetPosition(platform.transform), Quaternion.identity, this.transform);
			this.towers.Add(instantiate);
			CanvasUI.Instance.TowerCount(++this._counter, App.Towers);
			return instantiate;
		}

		public void DestroyTower(GameObject tower) {
			Destroy(tower);
			this.towers.Remove(tower);
			CanvasUI.Instance.TowerCount(--this._counter, App.Towers);
		}

		public bool CheckTower() {
			return this._counter != App.Towers;
		}

		private Vector3 GetPosition(Transform platform) {
			var position = platform.position;
			var parentScale = platform.localScale;
			var localScale = this.gameObject.transform.localScale;
			return new Vector3(position.x, position.y + parentScale.y / 2 + localScale.y / 2, position.z);
		}
	}
}
