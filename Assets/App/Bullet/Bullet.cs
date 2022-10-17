using UnityEngine;

namespace App.Bullet {
	public class Bullet : MonoBehaviour {
		private const int Speed = 10;
		private Transform _target;

		private void Update() {
			this.Flight();
		}

		private void Flight() {
			this.transform.Translate(this.transform.forward * (Speed * Time.deltaTime));
		}
	}
}
