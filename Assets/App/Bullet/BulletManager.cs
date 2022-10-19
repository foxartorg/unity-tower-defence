using Common;
using UnityEngine;

namespace App.Bullet {
	public class BulletManager : Singleton<BulletManager> {
		[SerializeField] private GameObject bulletPrefab;

		public GameObject Create(Transform parent) {
			return Instantiate(this.bulletPrefab, parent.position, parent.rotation, this.transform);
		}
	}
}
