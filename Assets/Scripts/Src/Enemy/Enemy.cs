using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Src.Enemy {
	public sealed class Enemy : MonoBehaviour {
		private const float Speed = 50;
		private const float SlowDown = 15;
		private int _health;
		private NavMeshAgent _navMeshAgent;
		private Slider _slider;

		private void Awake() {
			this._health = 100;
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			this._navMeshAgent.speed = Speed / SlowDown;
			this._navMeshAgent.acceleration = this._navMeshAgent.speed;
			this._slider = this.GetComponentInChildren<Slider>();
			this._slider.value = this._slider.maxValue = this._health;
		}

		private void Start() {
			this.MoveTo(EnemyManager.Instance.GetDestination());
		}

		private void OnTriggerEnter(Collider component) {
			if (App.IsBulletTag(component)) {
				this.ReceiveDamage(component.GetComponent<Bullet.Bullet>().GetDamage());
			}

			if (App.IsFinishTag(component)) {
				EnemyManager.Instance.DestroyEnemy(this.gameObject);
			}
		}

		private void MoveTo(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		private void ReceiveDamage(int damage) {
			this._health -= damage;
			this._slider.value = this._health;
			if (this._health > 0) {
				return;
			}

			EnemyManager.Instance.DestroyEnemy(this.gameObject);
		}
	}
}
