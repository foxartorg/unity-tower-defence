using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
	[SerializeField] private Transform movePositionTransform;
	private NavMeshAgent _navMeshAgent;

	// Start is called before the first frame update
	private void Awake() {
		_navMeshAgent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	private void Update() {
		_navMeshAgent.destination = movePositionTransform.position;
	}
}
