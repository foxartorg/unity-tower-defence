using System.Collections;
using UnityEngine;

namespace Enemy {
	public class SpawnEnemy : MonoBehaviour {
		[SerializeField] private GameObject enemyGameObject;
		[SerializeField] private int number;

		private void Start() {
			StartCoroutine(EnemySpawn());
		}

		private IEnumerator EnemySpawn() {
			for (var i = 0; i < number; i++) {
				var transform1 = transform;
				Instantiate(enemyGameObject, transform1.position, transform1.rotation, transform1);
				yield return new WaitForSeconds(0.5f);
			}
		}
	}
}
