using UnityEngine;

namespace Src.Enemy {
	public class EnemyEnd : MonoBehaviour {
		private void OnTriggerEnter(Collider other) {
			Debug.Log(other.tag);
		}
	}
}
