using UnityEngine;

namespace Src.Bullet {
	public class Bullet : MonoBehaviour {
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
			this.damage = Random.Range(100, 200);
			// Debug.Log($"BULLET {this._id}");
		}

		private void Update() {
			// this._transform.position += this._transform.forward * (Time.deltaTime * Velocity / 50);
			// this._transform.Translate(Vector3.forward * (Time.deltaTime * Velocity / 100));
			// this._rigidbody.AddForce(this._transform.forward * (Time.deltaTime * Velocity));
			this._rigidbody.velocity = this._transform.forward * (Time.deltaTime * Velocity);
			// this.v = Time.deltaTime;
		}

		private void OnCollisionEnter(Collision collision) {
			// Debug.Log($"COLLISION {collision.collider.name}");
			// if (collision.gameObject.CompareTag("Bullet")) {
			// 	return;
			// }
			BulletManager.Instance.DestroyBullet(this.gameObject);
			if (!collision.gameObject.CompareTag("Enemy")) { }

			// var damage = Random.Range(25, 50);
			// collision.collider.GetComponent<Enemy.Enemy>().Damage(damage);
		}

		public void SetDestination(GameObject destination) {
			this._transform.LookAt(destination.transform.localPosition);
			// this._rigidbody.AddForce(Vector3.Normalize(destination - this._transform.position) * Velocity / 4);
			// this._rigidbody.velocity = Vector3.Normalize(destination - this._transform.position) * (Time.deltaTime * Velocity);
		}
	}
}
