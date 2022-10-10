using System.Collections;
using UnityEngine;

namespace Tower {
	public class Bullet : MonoBehaviour {
		private const int Speed = 10;

		private void Awake() {
			StartCoroutine(DestroyBullet());
		}

		private void Update() {
			Flight();
		}

		private IEnumerator DestroyBullet() {
			yield return new WaitForSeconds(0.5f);
			Destroy(gameObject);
		}

		private void Flight() {
			transform.Translate(transform.forward * (Speed * Time.deltaTime));
		}
	}
}
