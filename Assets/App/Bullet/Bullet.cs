using App.Enemy;
using UnityEngine;

namespace App.Bullet {
	public class Bullet : MonoBehaviour {
		private const int Speed = 20;
		private Transform _target;

		private void Update() {
			this.CheckTarget();
		}

		private void CheckTarget() {
			var dir = EnemyManager.Instance.enemyTransform[0].position - this.transform.position;
			var distanceThisFrame = Speed * Time.deltaTime;
			this.transform.Translate(dir.normalized * distanceThisFrame);
			if (!(dir.magnitude <= distanceThisFrame)) {
				return;
			}

			Destroy(this.gameObject);
		}
	}
}
