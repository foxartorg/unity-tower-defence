using UnityEngine;

namespace Tower {
	public class Tower : MonoBehaviour {
		private const float FireRate = 2f;
		[SerializeField] private GameObject bulletGameObject;
		private float _timeout;
		private Transform _transform;

		private void Awake() {
			_transform = transform;
			_timeout = FireRate;
		}

		private void FixedUpdate() {
			Shoot();
		}

		private void Shoot() {
			if (_timeout < 0f) {
				Instantiate(bulletGameObject, _transform.position, _transform.rotation, transform);
				_timeout = FireRate;
			}

			_timeout -= Time.deltaTime;
		}
	}
}
