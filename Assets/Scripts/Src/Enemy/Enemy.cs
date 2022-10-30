using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Src.Enemy {
	public class Enemy : MonoBehaviour {
		private int _health = 100;
		private NavMeshAgent _navMeshAgent;
		private Slider _slider;
		public List<GameObject> enemies;

		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			// this._navMeshAgent.speed = 20;
			// this._navMeshAgent.acceleration = 64;
			this._slider = this.GetComponentInChildren<Slider>();
			this._slider.maxValue = this._health;
			this._slider.value = this._health;
		}

		private void Start() {
			// this.ExecCreate();
		}

		private void FixedUpdate() {
			// this.CheckDestination();
		}

		private void OnTriggerEnter(Collider trigger) {
			// var bullet = trigger.gameObject.GetComponent<Bullet.Bullet>();
			// var damage = trigger.gameObject.GetComponent<Bullet.Bullet>().damage;
			// Debug.Log($"TRIGGER {damage}");
			// BulletManager.Instance.DestroyBullet(bullet.gameObject);
			// this.Damage(bullet.damage);
		}

		public void Create(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		public void OnDestroy() {
		}

		public void Damage(int damage) {
			this._health -= damage;
			this._slider.value = this._health;
			if (this._health > 0) {
				return;
			}

			this.enemies.Remove(this.gameObject);
			Destroy(this.gameObject);
		}

		private void CheckDestination() {
			if (this._navMeshAgent.hasPath & (this._health > 0)) {
				return;
			}

			Debug.Log("DESTROY");
			// this.ExecDestroy(this.gameObject);
		}
	}
}
