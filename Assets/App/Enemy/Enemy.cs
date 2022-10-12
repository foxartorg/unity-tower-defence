using UnityEngine;
using UnityEngine.AI;

namespace App.Enemy {
	public class Enemy : MonoBehaviour {
		private NavMeshAgent _navMeshAgent;
		private int _counter;


		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
		}

		private void Update() {
			this.Destroy();
		}

		public void Go(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}

		private void Destroy() {
			if (!this._navMeshAgent.hasPath){
				Destroy(this.gameObject);
			}
		}
	}
}
