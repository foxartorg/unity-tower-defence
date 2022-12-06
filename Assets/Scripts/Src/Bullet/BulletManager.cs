using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Bullet {
	public sealed class BulletManager : MonoBehaviourSingleton<BulletManager> {
		[SerializeField] private GameObject bulletPrefab;
		private List<GameObject> _bulletList;
		private int _counter;
		private double _timeout;

		private void Awake() {
			this._bulletList = new List<GameObject>();
		}

		private void CreateBullet(Transform parentTransform, Transform destination) {
			// var bullet = this.gameObject.AddComponent<Bullet>();
			// bullet.SetDestination();
			var instantiate = Instantiate(this.bulletPrefab, parentTransform.position, parentTransform.rotation, this.transform);
			// Debug.Break();
			var bullet = instantiate.GetComponent<Bullet>();
			// var destination = new Vector3(0, 0.33f, 0);
			this._bulletList.Add(instantiate);
			bullet.SetDestination(destination.position);
			CanvasUI.Instance.BulletCounter(this._bulletList.Count);
		}

		public void DestroyBullet(GameObject bullet) {
			this._bulletList.Remove(bullet);
			CanvasUI.Instance.BulletCounter(this._bulletList.Count);
			Destroy(bullet);
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
