using Common;
using UnityEngine;

namespace App.Bullet {
	public class BulletManager : Manager {
		[SerializeField] private GameObject bulletPrefab;
		private static BulletManager Instance { get; set; }

		private void Awake() {
			Instance = this.SingleInstance<BulletManager>(this, Instance);
		}

		public void Create(Transform parentTransform) {
			var vector3 = Helper.PositionUpFromParent(this.bulletPrefab.transform, parentTransform);
			vector3.y /= 1.5f;
			Instantiate(this.bulletPrefab, vector3, parentTransform.rotation, this.transform);
		}
	}
}
