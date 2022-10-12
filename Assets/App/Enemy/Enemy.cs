using UnityEngine;
using UnityEngine.AI;

namespace App.Enemy {
	public class Enemy : MonoBehaviour {
		private NavMeshAgent _navMeshAgent;

		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
		}

		public void Go(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}
	}
}
