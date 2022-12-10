using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Src.Enemy {
	public sealed class Enemy : MonoBehaviour {
		private int _health;
		private NavMeshAgent _navMeshAgent;
		private Slider _slider;

		private void Awake() {
			this._health = 100;
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			this._navMeshAgent.speed = 50 / 50f;
			this._navMeshAgent.acceleration = this._navMeshAgent.speed * 2;
			this._navMeshAgent.angularSpeed = this._navMeshAgent.speed * 2;
			this._navMeshAgent.stoppingDistance = 0;
			this._navMeshAgent.autoBraking = false;
			this._slider = this.GetComponentInChildren<Slider>();
			this._slider.value = this._slider.maxValue = this._health;
		}

		private void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag("Bullet")) {
				// Debug.Log("bullet");
			}

			if (other.gameObject.CompareTag("SpawnStart")) {
				EnemyManager.Instance.MoveEnemy(this.gameObject);
			}

			if (other.gameObject.CompareTag("SpawnEnd")) {
				EnemyManager.Instance.DestroyEnemy(this.gameObject);
			}
		}

		private void OnTriggerExit(Collider other) {
			if (other.gameObject.CompareTag("Tower")) { }
		}

		public void MoveTo(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		public void MakeDamage(int damage) {
			this._health -= damage;
			this._slider.value = this._health;
			if (this._health > 0) {
				return;
			}

			EnemyManager.Instance.DestroyEnemy(this.gameObject);
			Destroy(this.gameObject);
		}
	}
}
