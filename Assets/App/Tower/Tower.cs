using UnityEngine;

namespace App.Tower {
	public class Tower : MonoBehaviour {
		private LineRenderer _lr;

		private void Awake() {
			// var destination = new Vector3(1, 1, 1);
			// this._lr = this.AddComponent<LineRenderer>();
			// this._lr.positionCount = 2;
			// this._lr.startWidth = 0.5f;
			// this._lr.endWidth = 0.1f;
			// this._lr.startColor = Color.green;
			// this._lr.endColor = Color.red;
			// this._lr.SetPosition(1, this.transform.position);
			// this._lr.SetPosition(2, destination);
		}

		private void Start() {
			// double randomFloat = Random.Range(0.1f, 1f);
			// this.StartCoroutine(BulletManager.Instance.Shoot(this.transform, (float)randomFloat));
			// var randomBool = Random.Range(0f, 1f) > 0.5;
			// if (randomBool) {
			// 	this.StartCoroutine(BulletManager.Instance.Shoot(this.transform, 0.1f));
			// } else {
			// 	this.StartCoroutine(BulletManager.Instance.Shoot(this.transform, 1f));
			// }
			// this.StartCoroutine(BulletManager.Instance.Shoot(this.transform));
		}

		private void OnDestroy() { }
	}
}
