using System.Collections.Generic;
using Common;
using UnityEngine;

namespace App.Bullet {
	public class BulletManager : Singleton<BulletManager> {
		[SerializeField] private GameObject bulletPrefab;
		public List<GameObject> _bulletList;

		private void Awake() {
			this._bulletList = new List<GameObject>();
		}

		public void Create(Transform parent) {
			var bullet = Instantiate(this.bulletPrefab, parent.position, parent.rotation, this.transform);
			this._bulletList.Add(bullet);
		}

		public void DestroyBullet(GameObject bullet) {
			this._bulletList.Remove(bullet);
			Destroy(bullet);
		}
	}
}
