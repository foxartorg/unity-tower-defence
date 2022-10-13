using System.Collections;
using UnityEngine;

namespace App.Bullet {
	public class Bullet : MonoBehaviour {
		private const int Speed = 10;
		private Transform _target;

		private void Awake() {
			this.StartCoroutine(this.DestroyBullet());
		}

		//TODO can we just once set destination and don't update on each frame
		private void Update() {
			this.Flight();
		}

		private IEnumerator DestroyBullet() {
			yield return new WaitForSeconds(0.5f);
			Destroy(this.gameObject);
		}

		private void Flight() {
			this.transform.Translate(this.transform.forward * (Speed * Time.deltaTime));
		}
	}
}
