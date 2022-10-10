using UnityEngine;

namespace UI {
	public class Tower : MonoBehaviour {
		[SerializeField] private GameObject bulletGameObject;
		private Transform _transform;
		private float _fireRate = 1f;

		private void Awake() {
			_transform = transform;
		}

		private void Update() {
			Shoot();
		}

		// TODO destroy bullet on screen exit
		private void Shoot() {
			if (_fireRate <= 0f) {
				Instantiate(bulletGameObject, _transform.position, _transform.rotation, transform);
				_fireRate = 1f;
			}

			_fireRate -= Time.deltaTime;
		}
	}
}
