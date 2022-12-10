using System.Collections.Generic;
using System.Linq;
using Scenes.GameScene;
using Src.Bullet;
using UnityEngine;
using UnityEngine.UI;

namespace Src.Tower {
	public class Tower : MonoBehaviour {
		private const float ShootTimeout = 0.5f;
		public List<GameObject> enemies;
		private Button _buttonHide;
		private Button _buttonSell;
		private Button _buttonUpgrade;
		private GameObject towerCanvas;
		private Transform _gunTransform;
		private Transform _headTransform;
		private Transform _muzzleTransform;
		private float _range;
		private Renderer _renderer;
		private float _timeout;
		private Transform _turretTransform;

		private Tower() {
			this.enemies = new List<GameObject>();
		}

		private void Awake() {
			this._range = 3;
			this.GetComponent<SphereCollider>().radius = this._range;
			this._renderer = this.GetComponentInChildren<Renderer>();
			this.towerCanvas = TowerManager.Instance.towerCanvas;
			// var buttons = this._canvas.transform.Find("Buttons");
			// var head = this._canvas.transform.Find("Head");
			// this._buttonUpgrade = this._canvas.transform.Find("Buttons").Find("Upgrade").GetComponent<Button>();
			// this._buttonSell = this._canvas.transform.Find("Buttons").Find("Sell").GetComponent<Button>();
			// this._buttonHide = this.gameObject.transform.Find("Hide").GetComponent<Button>();
			this._headTransform = this.transform.Find("Head");
			this._gunTransform = this.transform.Find("Head").Find("Gun");
			this._turretTransform = this.transform.Find("Head").Find("Turret");
			this._muzzleTransform = this.transform.Find("Head").Find("Muzzle");
			var position = this._gunTransform.position;
			this._muzzleTransform.position = new Vector3(position.x - this._gunTransform.localScale.x, position.y, position.z);
		}

		private void Start() {
			// this._buttonHide.onClick.AddListener(() => this._canvas.SetActive(false));
			// this._buttonSell.onClick.AddListener(() => TowerManager.Instance.RemoveTower(this.gameObject));
			// this._buttonUpgrade.onClick.AddListener(this.Upgrade);
		}

		private void OnDrawGizmos() {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, this._range);
		}

		private void OnMouseDown() {
			if (Input.GetMouseButtonDown(0)) {
				Instantiate(this.towerCanvas, this.transform.position, Quaternion.identity, this.transform);
			}
		}

		private void OnTriggerEnter(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this.enemies.Add(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this.enemies.Count);
		}

		private void OnTriggerExit(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this.enemies.Remove(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this.enemies.Count);
		}

		private void OnTriggerStay(Collider other) {
			if (!this.enemies[0]) {
				return;
			}

			if (!other.CompareTag("Enemy")) {
				return;
			}

			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			this._timeout = ShootTimeout;
			var direction = this._turretTransform.position - this.enemies[0].transform.position;
			var rotation = Quaternion.LookRotation(direction).eulerAngles;
			this._headTransform.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
			BulletManager.Instance.Shoot(this._muzzleTransform, this.enemies.First().transform);
		}

		public static GameObject Add(GameObject prefab, Vector3 position, Transform parent) {
			return Instantiate(prefab, position, Quaternion.identity, parent);
		}

		public void Remove() {
			Destroy(this.gameObject);
		}

		private void Upgrade() {
			this._renderer.material.color = Color.green;
		}
	}
}
