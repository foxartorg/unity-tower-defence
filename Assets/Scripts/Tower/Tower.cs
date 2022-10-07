using UnityEngine;

namespace Tower {
	public class Tower : MonoBehaviour {
		private float _fireCountDown = 1f;
		private const float FireRate = 0f;

		private void Update() {
			if (_fireCountDown <= 0f) {
				Shoot();
				_fireCountDown = 1f / FireRate;
			}

			_fireCountDown -= Time.deltaTime;
		}

		// ReSharper disable Unity.PerformanceAnalysis
		private void Shoot() {
			Debug.Log("Shoot!");
		}
	}
}
