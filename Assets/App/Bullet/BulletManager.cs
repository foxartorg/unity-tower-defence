using System.Collections;
using System.Collections.Generic;
using App.Enemy;
using Common;
using UnityEngine;

namespace App.Bullet {
	public class BulletManager : Singleton<BulletManager> {
		public const int Speed = 20;
		[SerializeField] private GameObject bulletPrefab;
		private List<GameObject> _bulletList;
		private double _timeout;

		private void Awake() {
			this._bulletList = new List<GameObject>();
		}

		public void Create(Transform parent) {
			var bullet = Instantiate(this.bulletPrefab, parent.position, parent.rotation, this.transform);
			this._bulletList.Add(bullet);
		}

		public float TimeBullet(Transform transformTower) {
			var dir = EnemyManager.Instance.enemyList[0].transform.position - transformTower.position;
			return dir.magnitude / Speed;
		}

		public void DestroyBullet(GameObject bullet) {
			this._bulletList.Remove(bullet);
			Destroy(bullet);
		}

		public IEnumerator Shoot(Transform tower, float timeout) {
			if (EnemyManager.Instance.enemyList.Count <= 0) {
				yield break;
			}

			this.Create(tower);
			yield return new WaitForSeconds(timeout);
			this.StartCoroutine(this.Shoot(tower, timeout));
		}
	}
}
