using UnityEngine;

namespace Src.Enemy {
	public sealed class EnemyEnd : MonoBehaviour {
		private void OnTriggerEnter(Collider other) {
			EnemyManager.Instance.DestroyEnemy(other.gameObject);
		}
	}
}
