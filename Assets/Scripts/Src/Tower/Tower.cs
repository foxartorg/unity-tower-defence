using System;
using System.Collections.Generic;
using System.Linq;
using Scenes.GameScene;
using Src.Bullet;
using TMPro;
using UnityEngine;

namespace Src.Tower {
	public class Tower : MonoBehaviour {
		private const float Timeout = 0.5f;
		public List<GameObject> enemies;
		private float _range;
		private float _timeout;
		private TextMeshProUGUI _towerCounterEnemy;

		private Tower() {
			this.enemies = new List<GameObject>();
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
			
			this.enemies.Add(other.gameObject);
			this.TextCounterEnemy();
			// Debug.Log("ENEMY ENTERED!");
		}

		private void OnTriggerExit(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this.enemies.Remove(other.gameObject);
			this.TextCounterEnemy();
			// Debug.Log("ENEMY EXIT!");
		}

		private void OnTriggerStay(Collider other) {
			this.TextCounterEnemy();
			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			if (!other.CompareTag("Enemy")) {
				return;
			}

			// BulletManager.Instance.Shoot(this.transform, this._enemies[^1].transform);
			var enemy = this.enemies.First();
			if (enemy) {
				BulletManager.Instance.Shoot(this.transform, enemy.transform);
			} else {
				Debug.Log("destroyed");
			}

			this._timeout = Timeout;
		}

		private void OnDestroy() {
			foreach (var enemy in this.enemies) {
				enemy.GetComponent<Enemy.Enemy>().towerList.Remove(this.gameObject);
			}
		}

		public void SetRange(int range) {
			this._range = range;
			this.GetComponent<SphereCollider>().radius = this._range;
		}

		private void TextCounterEnemy() {
			this._towerCounterEnemy.text = $"Enemies: {this.enemies.Count.ToString()}";
		}
	}
}
