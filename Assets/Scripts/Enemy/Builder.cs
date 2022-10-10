using UnityEngine;

namespace Enemy {
	public class Builder : MonoBehaviour {
		[SerializeField] public GameObject enemyGameObject;

		public GameObject CreateEnemy() {
			return enemyGameObject;
		}
	}
}
