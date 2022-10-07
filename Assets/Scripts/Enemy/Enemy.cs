using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
	public class Enemy : MonoBehaviour {
		private Transform _destination;
		private NavMeshAgent _navMeshAgent;

		// Start is called before the first frame update
		private void Awake() {
			_destination = GameObject.Find("Destination").transform;
			_navMeshAgent = GetComponent<NavMeshAgent>();

		}

		// Update is called once per frame
		private void Update() {

			_navMeshAgent.destination = _destination.position;
		}
	}

}
