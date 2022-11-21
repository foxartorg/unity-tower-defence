using System.Collections.Generic;
using System.Linq;
using Scenes.GameScene;
using Src.Bullet;
using TMPro;
using UnityEngine;

namespace Src.Tower {
	public class Tower : MonoBehaviour {
		private const float Timeout = 0.5f;
		private readonly List<GameObject> _enemies;
		private float _range;
		private float _timeout;
		private TextMeshProUGUI _towerCounterEnemy;

		private Tower() {
			this._enemies = new List<GameObject>();
		}

		private void Awake() {
			// this.GetComponent<SphereCollider>().radius = this._range;
			this._towerCounterEnemy = this.GetComponentInChildren<TextMeshProUGUI>();
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
			this._towerCounterEnemy.text = $"Enemies: {this._enemies.Count.ToString()}";
			// Debug.Log("ENEMY ENTERED!");
		}

		private void OnTriggerExit(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Remove(other.gameObject);
			this._towerCounterEnemy.text = $"Enemies: {this._enemies.Count.ToString()}";
			// Debug.Log("ENEMY EXIT!");
		}

		private void OnTriggerStay(Collider other) {
			this._towerCounterEnemy.text = $"Enemies: {this._enemies.Count.ToString()}";
			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			if (other.CompareTag("Enemy")) {
				BulletManager.Instance.Shoot(this.transform, this._enemies.First().transform);
			}

			this._timeout = Timeout;
		}

		public void SetRange(int range) {
			this._range = range;
			this.GetComponent<SphereCollider>().radius = this._range;
		}
	}
}
