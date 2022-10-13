using GameScene;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace App.Enemy {
	public class Enemy : MonoBehaviour {
		private NavMeshAgent _navMeshAgent;
		private int _counter;
		private int _health = 100;
		private TextMeshProUGUI _enemyHealthText;


		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			this._enemyHealthText = this.GetComponentInChildren<TextMeshProUGUI>();

		}

		private void Update() {
			CanvasUI.EnemyHealthText(this._health,this._enemyHealthText);
			this.DestroyEnemy();
		}

		public void Go(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		private void DestroyEnemy() {
			if (!this._navMeshAgent.hasPath || this._health <= 0){
				Destroy(this.gameObject);
			}
		}
	}
}
