using App.Bullet;
using App.Enemy;
using UnityEngine;

namespace App.Tower {
	public class Tower : MonoBehaviour {
		private const float FireRate = 2f;
		private float _timeout;

		private void Update() {
			this.Shoot();
		}

		private void Shoot() {
			if (this._timeout < 0f && EnemyManager.Instance.enemyList.Count != 0) {
				BulletManager.Instance.Create(this.transform);
				this._timeout = FireRate;
			}

			this._timeout -= Time.deltaTime;
		}
	}
}
