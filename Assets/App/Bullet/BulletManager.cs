using Common;
using UnityEngine;

namespace App.Bullet {
	public class BulletManager : Singleton<BulletManager> {
		[SerializeField] private GameObject bulletPrefab;

		public GameObject Create(Transform parentTransform) {
			var vector3 = Helper.PositionUpFromParent(this.bulletPrefab.transform, parentTransform);
			vector3.y /= 1.5f;
			return Instantiate(this.bulletPrefab, vector3, parentTransform.rotation, this.transform);
		}
	}
}
