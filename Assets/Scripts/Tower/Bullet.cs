using System.Collections;
using UnityEngine;

namespace Tower {
	public class Bullet : MonoBehaviour {
		private const int Speed = 30;

		private void Awake() {
			StartCoroutine(DestroyBullet());
		}

		private IEnumerator DestroyBullet() {
			yield return new WaitForSeconds(1);
			Destroy(gameObject);
		}

		private void Update() {
			Flight();
		}

		private void Flight() {
			var distanceThisFrame = Speed * Time.deltaTime;
			transform.Translate(transform.forward * distanceThisFrame);
		}
	}
}
