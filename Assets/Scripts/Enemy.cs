using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	[SerializeField] private Transform destination;
	private NavMeshAgent _navMeshAgent;

	// Start is called before the first frame update
	private void Awake() {
		_navMeshAgent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	private void Update() {
		
		
		_navMeshAgent.destination = destination.position;
	}
}
