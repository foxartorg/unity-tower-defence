using System;
using UnityEngine;

namespace App.Tower {
	public class Tower : MonoBehaviour {
		private const float FireRate = 2f;
		[SerializeField] private GameObject bulletGameObject;
		[SerializeField] private Transform target;
		private float _timeout;
		private Transform _transform;

		private void Awake() {
			_transform = transform;
			// _timeout = FireRate;
		}

		private void Update() {
			if (!target) { }
		}

		private void FixedUpdate() {
			Shoot();
		}

		private void Shoot() {
			if (_timeout < 0f) {
				Instantiate(bulletGameObject, _transform.position, _transform.rotation, _transform);
				_timeout = FireRate;
			}

			_timeout -= Time.deltaTime;
		}
	}
}
