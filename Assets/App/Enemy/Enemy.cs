using GameScene;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace App.Enemy {
	public class Enemy : MonoBehaviour {
		private NavMeshAgent _navMeshAgent;
		private int _health = 100;
		private Slider _enemyHealthSlider;
		private EnemyManager _enemyManager;


		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			this._enemyHealthSlider = this.GetComponentInChildren<Slider>();
			this._enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
			this._enemyHealthSlider.maxValue = this._health;


		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.F)) {
				this.EnemyDamage(20);
			}
			CanvasUI.EnemyHealthSlider(this._health,this._enemyHealthSlider);
			this.DestroyEnemy();
		}

		private void EnemyDamage(int damage) {
			this._health -= damage;
		}

		public void Go(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		private void DestroyEnemy() {
			if (this._navMeshAgent.hasPath && this._health > 0) {
				return;
			}

			this._enemyManager.counter -= 1;
			this._enemyManager._main.canvasUI.EnemyCounterText(this._enemyManager.counter);
			Destroy(this.gameObject);
		}
	}
}
