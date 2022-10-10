using UnityEngine;

namespace Tower {
	public class Tower : MonoBehaviour {
		[SerializeField] private GameObject bulletGameObject;
		private Transform _transform;
		private float _fireRate = 2f;

		private void Awake() {
			_transform = transform;
		}

		private void Update() {
			Shoot();
		}

		private void Shoot() {
			if (_fireRate <= 0f) {
				Instantiate(bulletGameObject, _transform.position, _transform.rotation, transform);
				_fireRate = 2f;
			}

			_fireRate -= Time.deltaTime;
		}
	}
}
