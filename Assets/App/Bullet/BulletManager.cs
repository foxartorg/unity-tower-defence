using System.Collections.Generic;
using App.Enemy;
using Common;
using UnityEngine;

namespace App.Bullet {
	public class BulletManager : Singleton<BulletManager> {
		[SerializeField] private GameObject bulletPrefab;
		private List<GameObject> _bulletList;
		public const int Speed = 20;

		private void Awake() {
			this._bulletList = new List<GameObject>();
		}

		public void Create(Transform parent) {
			var bullet = Instantiate(this.bulletPrefab, parent.position, parent.rotation, this.transform);
			this._bulletList.Add(bullet);
		}

		public static float TimeBullet(Transform transformTower) {
			var dir = EnemyManager.Instance.enemyList[0].transform.position - transformTower.position;
			return dir.magnitude / Speed;
		}

		public void DestroyBullet(GameObject bullet) {
			this._bulletList.Remove(bullet);
			Destroy(bullet);
		}
	}
}
