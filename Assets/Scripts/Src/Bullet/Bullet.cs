using UnityEngine;

namespace Src.Bullet {
	public sealed class Bullet : MonoBehaviour {
		private const int Velocity = 500;
		private static int _counter;
		private int _damage;
		private Vector3 _destination;
		private Rigidbody _rigidbody;
		private Transform _transform;

		private void Awake() {
			this._transform = this.transform;
			this._rigidbody = this.GetComponent<Rigidbody>();
			this._damage = Random.Range(25, 50);
		}

		private void Start() {
			// throw new NotImplementedException();
		}

		private void Update() {
			// this._transform.position += this._transform.forward * (Time.deltaTime * Velocity);
			// this._transform.Translate(Vector3.forward * (Time.deltaTime * Velocity));
			// this._rigidbody.AddForce(this._transform.forward * (Time.deltaTime * Velocity));
			this._rigidbody.velocity = this._transform.forward * (Time.deltaTime * Velocity);
		}

		private void OnTriggerEnter(Collider other) {
			BulletManager.Instance.DestroyBullet(this.gameObject);
			if (!other.CompareTag("Enemy")) {
				return;
			}

			other.gameObject.GetComponent<Enemy.Enemy>().MakeDamage(this._damage);
		}

		public void MoveTo(Vector3 destination) {
			this._transform.LookAt(destination);
			// this._rigidbody.AddForce(Vector3.Normalize(destination - this._transform.position) * Velocity);
			// this._rigidbody.velocity = Vector3.Normalize(destination - this._transform.position) * (Time.deltaTime * Velocity);
		}
	}
}
