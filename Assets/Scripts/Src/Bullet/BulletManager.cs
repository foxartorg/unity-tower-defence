using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Bullet {
	public sealed class BulletManager : MonoInstance<BulletManager> {
		[SerializeField] private GameObject bulletPrefab;
		private readonly List<GameObject> _bulletList;
		private int _counter;
		private double _timeout;

		private BulletManager() {
			this._bulletList = new List<GameObject>();
		}

		private static Bullet GetBullet(GameObject bullet) {
			return bullet.GetComponent<Bullet>();
		}

		private void CreateBullet(Transform parent, Transform destination) {
			// var bullet = this.gameObject.AddComponent<Bullet>();
			// this._bulletList.Add(bullet.gameObject);
			var bullet = Instantiate(this.bulletPrefab, parent.position, Quaternion.identity, this.transform);
			GetBullet(bullet).MoveTo(destination.position);
			// this.MoveBullet(bullet, destination.position);
			this._bulletList.Add(bullet);
			CanvasUI.Instance.BulletCounter(this._bulletList.Count);
		}

		public void DestroyBullet(GameObject bullet) {
			this._bulletList.Remove(bullet);
			Destroy(bullet);
			CanvasUI.Instance.BulletCounter(this._bulletList.Count);
		}

		public void MoveBullet(GameObject bullet, Vector3 position) {
			GetBullet(bullet).MoveTo(position);
		}

		public void Shoot(Transform towerTransform, Transform destination) {
			// if (EnemyManager.Instance.enemyList.Count <= 0) {
			// 	yield break;
			// }
			if (destination) {
				this.CreateBullet(towerTransform, destination);
			}
			// this.StartCoroutine(this.Shoot(towerTransform, destination));
		}
	}
}
