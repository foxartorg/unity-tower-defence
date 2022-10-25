using App.Bullet;
using UnityEngine;

namespace App.Tower {
	public class Tower : MonoBehaviour {
		private void Start() {
			// double randomFloat = Random.Range(0.1f, 1f);
			// this.StartCoroutine(BulletManager.Instance.Shoot(this.transform, (float)randomFloat));
			var randomBool = Random.Range(0f, 1f) > 0.5;
			if (randomBool) {
				this.StartCoroutine(BulletManager.Instance.Shoot(this.transform, 0.1f));
			} else {
				this.StartCoroutine(BulletManager.Instance.Shoot(this.transform, 1f));
			}
		}

		private void OnDestroy() { }
	}
}
