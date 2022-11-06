using UnityEngine;

namespace Src.Enemy {
	public sealed class EnemyEnd : MonoBehaviour {
		private void OnTriggerEnter(Collider other) {
			// Debug.Log(other.tag);
		}
	}
}
