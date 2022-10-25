using Common;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace App.Enemy {
	public class Enemy : Subscriber {
		private int _health = 100;
		private NavMeshAgent _navMeshAgent;
		private Slider _slider;

		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			// this._navMeshAgent.speed = 20;
			// this._navMeshAgent.acceleration = 64;
			this._slider = this.GetComponentInChildren<Slider>();
			this._slider.maxValue = this._health;
			this._slider.value = this._health;
		}

		private void Start() {
			this.ExecCreate();
		}

		private void FixedUpdate() {
			this.CheckDestination();
		}

		private void OnTriggerEnter(Collider trigger) {
			var damage = trigger.gameObject.GetComponent<Bullet.Bullet>().damage;
			Debug.Log($"TRIGGER {damage}");
			this.Damage(damage);
		}

		public void Damage(int damage) {
			this._health -= damage;
			this._slider.value = this._health;
			if (this._health <= 0) {
				this.ExecDestroy(this.gameObject);
			}
		}

		public void Go(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		private void CheckDestination() {
			if (this._navMeshAgent.hasPath) {
				return;
			}

			this.ExecDestroy(this.gameObject);
		}
	}
}
