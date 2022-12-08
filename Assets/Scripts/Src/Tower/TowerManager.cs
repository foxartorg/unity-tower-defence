using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Tower {
	public sealed class TowerManager : MonoComponent<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		[SerializeField] public GameObject towerCanvas;
		private int _counter;

		private static Tower GetTower(GameObject tower) {
			return tower.GetComponent<Tower>();
		}

		private Vector3 GetPosition(Transform platform) {
			var position = platform.position;
			var parentScale = platform.localScale;
			var localScale = this.gameObject.transform.localScale;
			return new Vector3(position.x, position.y + parentScale.y / 2 + localScale.y / 2, position.z);
		}

		public GameObject AddTower(GameObject platform) {
			if (this._counter >= App.Towers) {
				return null;
			}

			var tower = Tower.Add(this.towerPrefab, this.GetPosition(platform.transform), this.transform);
			CanvasUI.Instance.TowerCount(++this._counter, App.Towers);
			return tower;
		}

		public void RemoveTower(GameObject tower) {
			GetTower(tower).Remove();
			CanvasUI.Instance.TowerCount(--this._counter, App.Towers);
		}
	}
}
