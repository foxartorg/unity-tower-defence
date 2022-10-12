using UnityEngine;

namespace App.Tower {
	public class Tower : MonoBehaviour {
		private const float FireRate = 2f;
		[SerializeField] private GameObject bulletGameObject;
		private float _timeout;
		private Transform _transform;
		[SerializeField] private Transform target;
		private const int Range = 15;

		private void Start() {
			InvokeRepeating(nameof(UpdateTarget), 0f, 05f);
		}

		private void Update() {
			if (!target) {
			}
		}

		private void UpdateTarget() {
			var enemies = GameObject.FindGameObjectsWithTag("Enemy");
			var shortestDistance = Mathf.Infinity;
			GameObject nearestEnemy = null;

			foreach (var enemy in enemies) {
				var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
				if (!(distanceToEnemy < shortestDistance)) {
					continue;
				}

				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}

			if (nearestEnemy != null && shortestDistance <= Range) {
				target = nearestEnemy.transform;
			} else {
				target = null;
			}
		}

		private void Awake() {
			_transform = transform;
			// _timeout = FireRate;
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
