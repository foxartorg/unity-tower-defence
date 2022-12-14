using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Tower {
	public sealed class TowerManager : MonoInstance<TowerManager> {
		[SerializeField] private GameObject towerPrefab;
		[SerializeField] public GameObject towerCanvas;
		private readonly List<GameObject> _towerList;

		private TowerManager() {
			this._towerList = new List<GameObject>();
		}

		public void CreateTower(GameObject platform) {
			if (!this.CanCreate()) {
				Helper.ThrowError("tower limit exceeded");
			}

			var tower = Instantiate(this.towerPrefab, this.GetPosition(platform.transform), Quaternion.identity, this.transform);
			this._towerList.Add(tower);
			CanvasUI.Instance.TowerCount(this._towerList.Count, App.Towers);
		}

		public void DestroyTower(GameObject tower) {
			Destroy(tower);
			this._towerList.Remove(tower);
			CanvasUI.Instance.TowerCount(this._towerList.Count, App.Towers);
		}

		public bool CanCreate() {
			return this._towerList.Count != App.Towers;
		}

		private Vector3 GetPosition(Transform platform) {
			var position = platform.position;
			var parentScale = platform.localScale;
			var localScale = this.gameObject.transform.localScale;
			return new Vector3(position.x, position.y + parentScale.y / 2 + localScale.y / 2, position.z);
		}
	}
}
