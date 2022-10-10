using UnityEngine;

namespace UI {
	public class Tower : MonoBehaviour {
		[SerializeField] private GameObject bulletPrefab;
		[SerializeField] private Transform firePoint;
		private float _fireRate = 1f;

		private void Update() {
			Shoot();
		}

		private void Shoot() {
			if (_fireRate <= 0f) {
				Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, transform);
				_fireRate = 1f;
			}

			_fireRate -= Time.deltaTime;
		}
	}
}
