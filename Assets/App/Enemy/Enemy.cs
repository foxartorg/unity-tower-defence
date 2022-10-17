using GameScene;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace App.Enemy {
	public class Enemy : EnemyBuilder {
		private readonly int _health = 100;
		private Slider _enemyHealthSlider;
		private EnemyManager _enemyManager;
		private NavMeshAgent _navMeshAgent;

		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			this._enemyHealthSlider = this.GetComponentInChildren<Slider>();
			this._enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
			this._enemyHealthSlider.maxValue = this._health;
			// this.OnDestroyEnemy += this.TestExtend;
			// this.OnDestroyEnemy += () => Debug.Log(o.name);
		}

		private void Update() {
			CanvasUI.EnemyHealthSlider(this._health, this._enemyHealthSlider);
			this.CheckEnemy();
		}

		public void Go(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		private void CheckEnemy() {
			if (this._navMeshAgent.hasPath && this._health > 0) {
				return;
			}

			this.DestroyEnemy();
			// this._enemyManager.counter -= 1;
			// this._enemyManager._main.canvasUI.EnemyCounterText(this._enemyManager.counter);
			Destroy(this.gameObject);
		}
	}
}
