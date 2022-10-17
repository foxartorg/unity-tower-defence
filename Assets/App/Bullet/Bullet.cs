using App.Enemy;
using UnityEngine;

namespace App.Bullet {
	public class Bullet : MonoBehaviour {
		private const int Speed = 20;
		private Transform _target;
		private EnemyManager _enemyManager;

		private void Awake() {
			this._enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
		}

		private void CheckTarget() {
			var dir = this._enemyManager.enemyTransform[0].position - this.transform.position;
			var distanceThisFrame = Speed * Time.deltaTime;
			this.transform.Translate(dir.normalized * distanceThisFrame);
			if (!(dir.magnitude <= distanceThisFrame)) {
				return;
			}

			Destroy(this.gameObject);
		}

		private void Update() {
			this.CheckTarget();
		}
	}
}
