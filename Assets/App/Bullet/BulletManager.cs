using System.Collections;
using Common;
using GameScene;
using UnityEngine;

namespace App.Bullet {
	public class BulletManager : Singleton<BulletManager> {
		private const float ShootDelay = 0.25f;
		[SerializeField] private GameObject bulletPrefab;
		private int _counter;

		// private List<GameObject> _bulletList;
		private double _timeout;

		private void Awake() {
			// this._bulletList = new List<GameObject>();
		}

		public void CreateBullet(Transform parentTransform) {
			// var bullet = this.gameObject.AddComponent<Bullet>();
			// bullet.SetDestination();
			var pos = Helper.PositionParentUp(this.bulletPrefab.transform, parentTransform);
			var instantiate = Instantiate(this.bulletPrefab, new Vector3(pos.x, pos.y + 0.5f, pos.z), parentTransform.rotation,
				this.transform);
			// Debug.Break();
			var bullet = instantiate.GetComponent<Bullet>();
			var destination = new Vector3(0, 0.33f, 0);
			bullet.SetDestination(destination);
			CanvasUI.Instance.BulletCounter(++this._counter);
		}

		public void DestroyBullet(GameObject bullet) {
			CanvasUI.Instance.BulletCounter(--this._counter);
			Destroy(bullet);
		}

		public IEnumerator Shoot(Transform towerTransform) {
			// if (EnemyManager.Instance.enemyList.Count <= 0) {
			// 	yield break;
			// }
			yield return new WaitForSeconds(ShootDelay);
			this.CreateBullet(towerTransform);
			this.StartCoroutine(this.Shoot(towerTransform));
		}
	}
}
