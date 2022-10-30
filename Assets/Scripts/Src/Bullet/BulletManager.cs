using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Bullet {
	public class BulletManager : MonoBehaviourSingleton<BulletManager> {
		private const float ShootDelay = 0.25f;
		[SerializeField] private GameObject bulletPrefab;
		private int _counter;

		// private List<GameObject> _bulletList;
		private double _timeout;

		private void Awake() {
			// this._bulletList = new List<GameObject>();
		}

		public void CreateBullet(Transform parentTransform, Transform destination) {
			// var bullet = this.gameObject.AddComponent<Bullet>();
			// bullet.SetDestination();
			var pos = Helper.PositionParentUp(this.bulletPrefab.transform, parentTransform);
			var instantiate = Instantiate(this.bulletPrefab, new Vector3(pos.x, pos.y + 0.5f, pos.z), parentTransform.rotation,
				this.transform);
			// Debug.Break();
			var bullet = instantiate.GetComponent<Bullet>();
			// var destination = new Vector3(0, 0.33f, 0);
			bullet.SetDestination(destination.position);
			CanvasUI.Instance.BulletCounter(++this._counter);
		}

		public void DestroyBullet(GameObject bullet) {
			CanvasUI.Instance.BulletCounter(--this._counter);
			Destroy(bullet);
		}

		public void Shoot(Transform towerTransform, Transform destination) {
			// if (EnemyManager.Instance.enemyList.Count <= 0) {
			// 	yield break;
			// }
			this.CreateBullet(towerTransform, destination);
			// this.StartCoroutine(this.Shoot(towerTransform, destination));
		}
	}
}
