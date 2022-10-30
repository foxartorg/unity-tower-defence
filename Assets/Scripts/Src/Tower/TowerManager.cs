using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Tower {
	public sealed class TowerManager : MonoBehaviourSingleton<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		private int _counter;

		public GameObject AddTower(GameObject parent) {
			if (this._counter >= App.Towers) {
				return null;
			}

			CanvasUI.Instance.TowerCount(++this._counter, App.Towers);
			var position = Helper.PositionParentUp(this.towerPrefab.transform, parent.transform);
			var tower = Instantiate(this.towerPrefab, position, Quaternion.identity, this.transform);
			tower.GetComponent<Tower>().SetRange(5);
			;
			return tower;
		}

		public GameObject DeleteTower(GameObject tower) {
			CanvasUI.Instance.TowerCount(--this._counter, App.Towers);
			Destroy(tower);
			return null;
		}
	}
}
