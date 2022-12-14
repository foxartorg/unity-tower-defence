using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using Src.Bullet;
using UnityEngine;

namespace Src.Tower {
	public class Tower : MonoInstance<Tower> {
		private const float ShootTimeout = 0.1f;
		private readonly List<GameObject> _enemyList;
		private Transform _gunTransform;
		private Transform _headTransform;
		private Transform _muzzleTransform;
		private float _range;
		private Renderer _renderer;
		private float _timeout;
		private Transform _turretTransform;

		private Tower() {
			this._enemyList = new List<GameObject>();
		}

		public GameObject Platform { get; set; }

		private void Awake() {
			this.GetComponentInChildren<SphereCollider>().radius = this._range = 6f;
			this._renderer = this.GetComponentInChildren<Renderer>();
			this._headTransform = this.transform.Find("Head");
			this._turretTransform = this._headTransform.Find("Turret");
			this._muzzleTransform = this._headTransform.Find("Muzzle");
			var gunTransform = this._headTransform.Find("Gun");
			this._muzzleTransform.position = Helper.PositionParentRight(gunTransform);
		}

		private void OnDrawGizmos() {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, this._range / 2);
		}

		private void OnMouseDown() {
			if (!Input.GetMouseButtonDown(0)) {
				return;
			}

			TowerMenu.Instance.Show(this.gameObject);
		}

		private void OnTriggerEnter(Collider component) {
			if (!App.IsEnemyTag(component)) {
				return;
			}

			this._enemyList.Add(component.gameObject);
			// UserInterface.Instance.TowerEnemyCount(this._enemyList.Count);
		}

		private void OnTriggerExit(Collider component) {
			if (!App.IsEnemyTag(component)) {
				return;
			}

			this._enemyList.Remove(component.gameObject);
			// UserInterface.Instance.TowerEnemyCount(this._enemyList.Count);
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
			this._headTransform.transform.rotation = Quaternion.Euler(0f, rotation.y + 90, rotation.z);
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

		public void Upgrade() {
			this._range += 1f;
			this._renderer.material.color = Color.green;
		}
	}
}
