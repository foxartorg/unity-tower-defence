using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Tower {
	public sealed class TowerManager : MonoInstance<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		private readonly List<GameObject> _towerList;
		private GameObject _towerMenu;

		private TowerManager() {
			this._towerList = new List<GameObject>();
		}

		public void CreateTower(GameObject platform) {
			if (!this.CanCreate()) {
				Helper.ThrowError("tower limit exceeded");
			}

			var position = Helper.PositionParentUp(platform.transform, this.towerPrefab.transform);
			var tower = Instantiate(this.towerPrefab, position, Quaternion.identity, this.transform);
			this._towerList.Add(tower);
			UserInterface.Instance.TowerCount(this._towerList.Count, App.Towers);
		}

		public void DestroyTower(GameObject tower) {
			Destroy(tower);
			this._towerList.Remove(tower);
			UserInterface.Instance.TowerCount(this._towerList.Count, App.Towers);
		}

		public void UpgradeTower(GameObject tower) {
			tower.GetComponent<Tower>().Upgrade();
		}

		public bool CanCreate() {
			return this._towerList.Count != App.Towers;
		}
	}
}
