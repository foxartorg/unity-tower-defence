using Common;
using UnityEngine;

namespace App.Bullet {
	public class BulletManager : Singleton<BulletManager> {
		[SerializeField] private GameObject bulletPrefab;

		public void Create(Transform parent) {
			Instantiate(this.bulletPrefab, parent.position, parent.rotation, this.transform);
		}
	}
}
