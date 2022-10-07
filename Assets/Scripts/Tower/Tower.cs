using UnityEngine;

namespace Tower {
	public class Tower : MonoBehaviour {
		[SerializeField] private GameObject bulletPrefab;
		[SerializeField] private Transform firePoint;
		private float _fireCountDown = 1f;

		private void Update() {
			if (_fireCountDown <= 0f) {
				Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, transform);
				_fireCountDown = 1f;
			}
			_fireCountDown -= Time.deltaTime;
		}
	}
}
