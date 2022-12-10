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
			this._range = 3;
			this.GetComponent<SphereCollider>().radius = this._range;
			this._renderer = this.GetComponentInChildren<Renderer>();
			this._towerCanvas = TowerManager.Instance.towerCanvas;
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
			if (!Input.GetMouseButtonDown(0)) {
				return;
			}

			var canvas = Instantiate(this._towerCanvas, this.transform.position, Quaternion.identity, this.transform);
			canvas.SetActive(false);
		}

		private void OnTriggerEnter(Collider obj) {
			if (!App.IsEnemyTag(obj)) {
				return;
			}

			this._enemyList.Add(obj.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemyList.Count);
		}

		private void OnTriggerExit(Collider obj) {
			if (!App.IsEnemyTag(obj)) {
				return;
			}

			this._enemyList.Remove(obj.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemyList.Count);
		}

		private void OnTriggerStay(Collider obj) {
			if (!App.IsEnemyTag(obj)) {
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

		private void RotateHead(Vector3 position) {
			var direction = this._turretTransform.position - position;
			var rotation = Quaternion.LookRotation(direction).eulerAngles;
			this._headTransform.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		}

		private void Shoot() {
			var position = this.FindEnemyPosition();
			if (position == default) {
				return;
			}

			this.RotateHead(position);
			var bullet = BulletManager.Instance.CreateBullet(this._muzzleTransform);
			bullet.GetComponent<Bullet.Bullet>().MoveTo(position);
		}

		private void Upgrade() {
			this._renderer.material.color = Color.green;
		}
	}
}
