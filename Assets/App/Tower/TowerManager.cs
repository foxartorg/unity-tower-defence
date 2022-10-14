using Common;
using GameScene;
using UnityEngine;

namespace App.Tower {
	public class TowerManager : Manager {
		[SerializeField] public GameObject towerGameObject;
		private int _counter;
		private EventSystem _eventSystem;
		private Main _main;
		private Renderer _renderer;
		public static TowerManager Instance { get; private set; }

		private void Awake() {
			Instance = this.SingleInstance<TowerManager>(this, Instance);
			this._main = Helper.FindComponent<Main>("Main");
			this._eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		}

		private void Update() {
			// this.DestroyTower();
		}

		public GameObject Create(Transform parentTransform) {
			this._main.canvasUI.TowerCountText(++this._counter);
			var vector3 = Helper.PositionUpFromParent(this.towerGameObject.transform, parentTransform);
			return Instantiate(this.towerGameObject, vector3, parentTransform.rotation, this.transform);
		}

		public void DestroyTower() {
			Debug.Log("XXX");
		}
	}
}
