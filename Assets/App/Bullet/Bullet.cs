using App.Enemy;
using UnityEngine;

namespace App.Bullet {
	public class Bullet : MonoBehaviour {
		private const int Speed = 10;
		private Enemy.Enemy _enemy;
		private Transform _target;

		private void Awake() {
		}

		private void Update() {
			this.CheckTarget();
		}

		// ReSharper disable Unity.PerformanceAnalysis
		private void CheckTarget() {
			if (EnemyManager.Instance.enemyList.Count == 0) {
				BulletManager.Instance.DestroyBullet(this.gameObject);
				return;
			}

			this._enemy = EnemyManager.Instance.enemyList[0].GetComponent<Enemy.Enemy>();
			var dir = this._enemy.transform.position - this.transform.position;
			var distanceThisFrame = Speed * Time.deltaTime;
			this.transform.Translate(dir.normalized * distanceThisFrame);
			if (!(dir.magnitude <= distanceThisFrame)) {
				return;
			}

			this._enemy.TakingAwayHp(50);
			BulletManager.Instance.DestroyBullet(this.gameObject);
		}
	}
}
