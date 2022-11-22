using System.Collections.Generic;
using System.Linq;
using Scenes.GameScene;
using Src.Bullet;
using UnityEngine;

namespace Src.Tower {
	public class Tower : MonoBehaviour {
		private const float Timeout = 0.5f;
		private readonly List<GameObject> _enemies;
		private float _range;
		private float _timeout;
		private Transform _gunTransform;

		private Tower() {
			this._enemies = new List<GameObject>();
		}
		
		private void Awake() {
			this.GetComponentInChildren<SphereCollider>().radius = this._range;
			this._gunTransform = this.transform.Find("FirePoint");
		}
		
		private void OnDrawGizmos() {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, this._range / 2);
		}

		private void OnMouseEnter() {
			Debug.Log("Tower OnMouseEnter");
		}

		private void OnTriggerEnter(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Add(other.gameObject);
			other.gameObject.GetComponent<Enemy.Enemy>().enemies = this._enemies;
			CanvasUI.Instance.TowerEnemyCount(this._enemies.Count);
			// Debug.Log("ENEMY ENTERED!");
		}

		private void OnTriggerExit(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Remove(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemies.Count); 
			// Debug.Log("ENEMY EXIT!");
		}

		private void OnTriggerStay(Collider other) {
   			var dir = this.transform.position - this._enemies.First().transform.position;
			var lookRotation = Quaternion.LookRotation(dir);
			var rotation = lookRotation.eulerAngles;
			this.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			if (other.CompareTag("Enemy")) {
				BulletManager.Instance.Shoot(this._gunTransform, this._enemies.First().transform);
			}

			this._timeout = Timeout;
		}

		public void SetRange(int range) {
			this._range = range;
			this.GetComponentInChildren<SphereCollider>().radius = this._range;
		}
	}
}
