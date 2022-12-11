using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Bullet {
	public sealed class BulletManager : MonoInstance<BulletManager> {
		[SerializeField] private GameObject bulletPrefab;
		private readonly List<GameObject> _bulletList;

		private BulletManager() {
			this._bulletList = new List<GameObject>();
		}

		public GameObject CreateBullet(Transform parent) {
			var bullet = Instantiate(this.bulletPrefab, parent.position, Quaternion.identity, this.transform);
			this._bulletList.Add(bullet);
			CanvasUI.Instance.BulletCounter(this._bulletList.Count);
			return bullet;
		}

		public void DestroyBullet(GameObject bullet) {
			this._bulletList.Remove(bullet);
			Destroy(bullet);
			CanvasUI.Instance.BulletCounter(this._bulletList.Count);
		}
	}
}
