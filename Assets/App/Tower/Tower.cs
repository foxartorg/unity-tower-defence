using UnityEngine;

namespace App.Tower {
	public class Tower : MonoBehaviour {
		private const float FireRate = 2f;
		[SerializeField] private GameObject bulletGameObject;
		[SerializeField] private Transform target;
		private float _timeout;
		private Transform _transform;

		private void Awake() {
			this._transform = this.transform;
			// _timeout = FireRate;
		}

		private void FixedUpdate() {
			this.Shoot();
		}

		private void Shoot() {
			if (this._timeout < 0f) {
				Instantiate(this.bulletGameObject, this._transform.position, this._transform.rotation, this._transform);
				this._timeout = FireRate;
			}

			this._timeout -= Time.deltaTime;
		}
	}
}
