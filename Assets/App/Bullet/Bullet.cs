using System.Collections;
using UnityEngine;

namespace App.Bullet {
	public class Bullet : MonoBehaviour {
		private const int Speed = 10;

		private void Awake() {
			StartCoroutine(DestroyBullet());
		}

		//TODO can we just once set destination and don't update on each frame
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
