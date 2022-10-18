using App.Bullet;
using UnityEngine;

namespace App.Tower {
	public class Tower : MonoBehaviour {
		private const float FireRate = 2f;
		private BulletManager _bulletManager;
		private float _timeout;

		private void Awake() {
			this._bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
		}

		private void Update() {
			this.Shoot();
		}

		private void Shoot() {
			if (this._timeout < 0f) {
				this._bulletManager.Create(this.transform);
				this._timeout = FireRate;
			}

			this._timeout -= Time.deltaTime;
		}
	}
}
