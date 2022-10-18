using Common;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace App.Enemy {
	public class Enemy : Subscriber {
		private readonly int _health = 100;
		private Slider _enemyHealthSlider;
		private NavMeshAgent _navMeshAgent;

		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			this._enemyHealthSlider = this.GetComponentInChildren<Slider>();
			this._enemyHealthSlider.maxValue = this._health;
		}

		private void Update() {
			// CanvasUI.EnemyHealthSlider(this._health, this._enemyHealthSlider);
			this.CheckDestination();
		}

		public void Go(Vector3 position) {
			this.CreateHandler();
			this._navMeshAgent.SetDestination(position);
		}

		private void CheckDestination() {
			if (this._navMeshAgent.hasPath && this._health > 0) {
				return;
			}

			this.DestroyHandler();
			Destroy(this.gameObject);
		}
	}
}
