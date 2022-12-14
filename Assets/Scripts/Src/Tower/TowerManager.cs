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

			var tower = Instantiate(this.towerPrefab, this.GetPosition(platform.transform), Quaternion.identity, this.transform);
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

		private Vector3 GetPosition(Transform platform) {
			var position = platform.position;
			var localScale = platform.localScale;
			return new Vector3(position.x, position.y + localScale.y / 2 + this.towerPrefab.transform.localScale.y / 2, position.z);
		}
	}
}
