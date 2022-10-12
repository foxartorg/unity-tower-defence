using UnityEngine;
using UnityEngine.AI;

namespace App.Enemy {
	public class Enemy : MonoBehaviour {
		private NavMeshAgent _navMeshAgent;

		private void Awake() {
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		public void Go(Vector3 position) {
			_navMeshAgent.SetDestination(position);
		}
	}
}
