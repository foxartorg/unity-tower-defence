using System.Collections.Generic;
using Scenes.GameScene;
using Src.Bullet;
using UnityEngine;

namespace Src.Tower {
	public class Tower : MonoBehaviour {
		private readonly List<GameObject> _enemies;
		private LineRenderer _lr;
		private float _timeout;
		private const float Radius = 7;
		private SphereCollider _collider;

		private Tower() {
			this._enemies = new List<GameObject>();
		}

		private void Awake() {
			this._collider = this.GetComponent<SphereCollider>();
			this._collider.radius = Radius;
			this._timeout = 3f;
		}

		private void OnTriggerEnter(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Add(other.gameObject);
			other.gameObject.GetComponent<Enemy.Enemy>().enemies = this._enemies;
			CanvasUI.Instance.TowerEnemyCount(this._enemies.Count);
			Debug.Log("ENEMY ENTERED!");
		}

		private void OnTriggerExit(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Remove(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemies.Count);
			Debug.Log("ENEMY EXIT!");
		}

		private void OnTriggerStay(Collider other) {
			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			if (other.CompareTag("Enemy")) {
				BulletManager.Instance.Shoot(this.transform, this._enemies[0]);
				CanvasUI.Instance.TowerEnemyCount(this._enemies.Count);
			}
			this._timeout = 1f;
		}

		private void OnDrawGizmos() {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, Radius/2);
		}
	}
}
