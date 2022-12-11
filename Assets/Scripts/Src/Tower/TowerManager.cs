using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Tower {
	public sealed class TowerManager : MonoInstance<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		[SerializeField] public GameObject towerCanvas;
		private int _counter;

		public void CreateTower(GameObject platform) {
			if (!this.CheckTower()) {
				return;
			}

			Instantiate(this.towerPrefab, this.GetPosition(platform.transform), Quaternion.identity, this.transform);
			CanvasUI.Instance.TowerCount(++this._counter, App.Towers);
		}

		public void DestroyTower(GameObject tower) {
			Destroy(this.gameObject);
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
