using UnityEngine;

namespace Src.Bullet {
	public sealed class Bullet : MonoBehaviour {
		private const int Velocity = 50;
		private int _damage;
		private Rigidbody _rigidbody;
		private Transform _transform;

		private void Awake() {
			this._rigidbody = this.GetComponent<Rigidbody>();
			this._damage = Random.Range(25, 50);
		}

		private void Update() {
			// this._transform.position += this._transform.forward * (Time.deltaTime * Velocity);
			// this._transform.Translate(Vector3.forward * (Time.deltaTime * Velocity));
			// this._rigidbody.AddForce(this._transform.forward * (Time.deltaTime * Velocity));
			this._rigidbody.velocity = this.transform.forward * (Time.deltaTime * Velocity);
		}

		private void OnTriggerEnter(Collider component) {
			BulletManager.Instance.DestroyBullet(this.gameObject);
		}

		public int GetDamage() {
			return this._damage;
		}

		public void MoveTo(Vector3 destination) {
			this.transform.LookAt(destination);
			// this._rigidbody.AddForce(Vector3.Normalize(destination - this._transform.position) * Velocity);
			// this._rigidbody.velocity = Vector3.Normalize(destination - this._transform.position) * (Time.deltaTime * Velocity);
		}
	}
}
