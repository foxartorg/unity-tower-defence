using UnityEngine;

namespace Src.Bullet {
	public sealed class Bullet : MonoBehaviour {
		private const int Velocity = 1000;
		private static int _counter;
		public int damage;
		[SerializeField] private float v;
		private Vector3 _destination;
		private int _id;
		private Rigidbody _rigidbody;
		private Transform _transform;

		private void Awake() {
			this._transform = this.transform;
			this._rigidbody = this.GetComponent<Rigidbody>();
			this._id = _counter++;
			this.damage = Random.Range(25, 50);
		}

		private void Update() {
			// this._transform.position += this._transform.forward * (Time.deltaTime * Velocity / 50);
			// this._transform.Translate(Vector3.forward * (Time.deltaTime * Velocity / 100));
			// this._rigidbody.AddForce(this._transform.forward * (Time.deltaTime * Velocity));
			// this._rigidbody.velocity = this._transform.forward * (Time.deltaTime * Velocity);
		}

		private void OnTriggerEnter(Collider other) {
			BulletManager.Instance.DestroyBullet(this.gameObject);
			if (!other.CompareTag("Enemy")) {
				return;
			}

			other.gameObject.GetComponent<Enemy.Enemy>().Damage(this.damage);
		}

		public void SetDestination(Vector3 destination) {
			// this._transform.LookAt(destination.transform.position);
			// this._rigidbody.AddForce(Vector3.Normalize(destination - this._transform.position) * Velocity / 4);
			this._rigidbody.velocity = Vector3.Normalize(destination - this._transform.position) * (Time.deltaTime * Velocity);
		}
	}
}
