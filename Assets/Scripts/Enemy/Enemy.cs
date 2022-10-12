using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
	public class Enemy : MonoBehaviour {
		private NavMeshAgent _navMeshAgent;

		private void Awake() {
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private void Update() {
			Destroy();
		}

		public void Go(Vector3 position) {
			_navMeshAgent.SetDestination(position);
		}

		private void Destroy() {
			if (!_navMeshAgent.hasPath){
				Destroy(gameObject);
			}
		}
	}
}
