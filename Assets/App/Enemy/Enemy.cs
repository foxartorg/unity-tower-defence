using Common;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace App.Enemy {
	public class Enemy : Subscriber {
		private int _health = 150;
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

		private void Update() {
			this.CheckDestination();
		}

		public void TakingAwayHp(int damage) {
			this._health -= damage;
			this._slider.value = this._health;
		}

		public void Go(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		private void CheckDestination() {
			if (this._navMeshAgent.hasPath && this._health > 0) {
				return;
			}

			this.ExecDestroy(this.gameObject);
		}
	}
}
