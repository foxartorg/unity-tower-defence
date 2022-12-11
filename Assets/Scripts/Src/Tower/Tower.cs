using System.Collections.Generic;
using Scenes.GameScene;
using Src.Bullet;
using UnityEngine;
using UnityEngine.UI;

namespace Src.Tower {
	public class Tower : MonoBehaviour {
		private const float ShootTimeout = 3f;
		private readonly List<GameObject> _enemyList;
		private Button _buttonHide;
		private Button _buttonSell;
		private Button _buttonUpgrade;
		private Transform _gunTransform;
		private Transform _headTransform;
		private GameObject _menu;
		private Transform _muzzleTransform;
		private float _range;
		private Renderer _renderer;
		private float _timeout;
		private GameObject _towerCanvas;
		private Transform _turretTransform;

		private Tower() {
			this._enemyList = new List<GameObject>();
		}

		private void Awake() {
			this.GetComponent<SphereCollider>().radius = this._range = 3;
			this._renderer = this.GetComponentInChildren<Renderer>();
			// this.towerCanvasPrefab = TowerManager.Instance.towerCanvas;
			this._headTransform = this.transform.Find("Head");
			this._gunTransform = this._headTransform.Find("Gun");
			this._turretTransform = this._headTransform.Find("Turret");
			this._muzzleTransform = this._headTransform.Find("Muzzle");
			this._towerCanvas = TowerManager.Instance.towerCanvas;
			var position = this._gunTransform.position;
			this._muzzleTransform.position = new Vector3(position.x - this._gunTransform.localScale.x, position.y, position.z);
		}

		private void Start() {
			var tr = this.transform;
			var pos = tr.position;
			var position = new Vector3(pos.x, pos.y + 1f, pos.z);
			this._menu = Instantiate(this._towerCanvas, position, this._towerCanvas.transform.rotation, tr);
			this._menu.SetActive(false);
			var buttons = this._menu.transform.Find("Buttons");
			this._buttonUpgrade = buttons.Find("Upgrade").GetComponent<Button>();
			this._buttonSell = buttons.Find("Sell").GetComponent<Button>();
			this._buttonHide = buttons.Find("Hide").GetComponent<Button>();
			this._buttonUpgrade.onClick.AddListener(this.Upgrade);
			this._buttonSell.onClick.AddListener(() => TowerManager.Instance.DestroyTower(this.gameObject));
			this._buttonHide.onClick.AddListener(() => this._menu.SetActive(false));
		}

		private void OnDrawGizmos() {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, this._range);
		}

		private void OnMouseDown() {
			if (!Input.GetMouseButtonDown(0)) {
				return;
			}

			this._menu.SetActive(true);
		}

		// private void OnTriggerEnter(Collider other) {
		// 	if (!other.CompareTag("Enemy")) {
		// 		return;
		// 	}
		//
		// 	var selfTransform = this.transform;
		// 	var canvas = Instantiate(this._towerCanvas, selfTransform.position, Quaternion.identity, selfTransform);
		// 	canvas.SetActive(false);
		// }

		private void OnTriggerEnter(Collider component) {
			if (!App.IsEnemyTag(component)) {
				return;
			}

			this._enemyList.Add(component.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemyList.Count);
		}

		private void OnTriggerExit(Collider component) {
			if (!App.IsEnemyTag(component)) {
				return;
			}

			this._enemyList.Remove(component.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemyList.Count);
		}

		private void OnTriggerStay(Collider component) {
			if (!App.IsEnemyTag(component)) {
				return;
			}

			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			this._timeout = ShootTimeout;
			this.Shoot();
		}

		private Vector3 FindEnemyPosition() {
			return this._enemyList[0] ? this._enemyList[0].transform.position : default;
		}

		private void AimTo(Vector3 position) {
			var forward = this._turretTransform.position - position;
			var rotation = Quaternion.LookRotation(forward).eulerAngles;
			this._headTransform.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		}

		private void Shoot() {
			var position = this.FindEnemyPosition();
			if (position == default) {
				return;
			}

			this.AimTo(position);
			var bullet = BulletManager.Instance.CreateBullet(this._muzzleTransform);
			bullet.GetComponent<Bullet.Bullet>().MoveTo(position);
		}

		private void Upgrade() {
			this._range += 1f;
			this._renderer.material.color = Color.green;
		}
	}
}
