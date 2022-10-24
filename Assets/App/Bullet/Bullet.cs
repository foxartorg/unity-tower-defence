using App.Enemy;
using UnityEngine;

namespace App.Bullet {
	public class Bullet : MonoBehaviour  {
		private Enemy.Enemy _enemy;
		private Vector3 _dir;

		private void Awake() {
			this._enemy = EnemyManager.Instance.enemyList[0].GetComponent<Enemy.Enemy>();
			this._dir = this._enemy.transform.position - this.transform.position;
		}

		private void Update() {
			this.CheckTarget();
		}

		private void CheckTarget() {
			if (EnemyManager.Instance.enemyList.Count == 0) {
				BulletManager.Instance.DestroyBullet(this.gameObject);
				return;
			}

			var distanceThisFrame = BulletManager.Speed * Time.deltaTime;
			this.transform.Translate(this._dir.normalized * distanceThisFrame);
			if (!(this._dir.magnitude <= distanceThisFrame)) {
				return;
			}

			this._enemy.TakingAwayHp(50);
			BulletManager.Instance.DestroyBullet(this.gameObject);
		}
	}
}
