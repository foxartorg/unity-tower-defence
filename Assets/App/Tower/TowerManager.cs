using Common;
using GameScene;
using UnityEngine;

namespace App.Tower {
	public class TowerManager : Singleton {
		[SerializeField] private GameObject towerGameObject;
		private int _counter;
		private Main _main;
		private Renderer _renderer;
		public static TowerManager Instance { get; private set; }

		private void Awake() {
			Instance = GetInstance<TowerManager>();
			_main = Helper.FindComponent<Main>("Main");
		}

		public bool Create(Transform pTransform) {
			var position = pTransform.position;
			var localScale = pTransform.localScale;
			var y = position.y + localScale.y / 2 + towerGameObject.transform.localScale.y;
			var vector3 = new Vector3(position.x, y, position.z);
			Instantiate(towerGameObject, vector3, pTransform.rotation, transform);
			_main.canvasUI.TowerCountText(++_counter);
			return true;
		}
	}
}
