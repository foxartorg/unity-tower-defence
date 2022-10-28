using UnityEngine;

namespace App.Enemy {
	public class EnemyEnd : MonoBehaviour {
		private void OnTriggerEnter(Collider other) {
			Debug.Log(other.tag);
		}
	}
}
