using System.Collections.Generic;
using Scenes.GameScene;
using Src.Bullet;
using UnityEngine;

namespace Src.Tower {
	public class Tower : MonoBehaviour {
		private readonly List<GameObject> _enemies;
		private LineRenderer _lr;
		private float _timeout;

		private Tower() {
			this._enemies = new List<GameObject>();
		}

		private void Awake() {
			this._timeout = 3f;
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
		}

		private void OnTriggerEnter(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Add(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemies.Count);
			Debug.Log("ENEMY ENTERED!");
		}

		private void OnTriggerExit(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Remove(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemies.Count);
			Debug.Log("ENEMY EXIT!");
		}

		private void OnTriggerStay(Collider other) {
			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			if (other.CompareTag("Enemy")) {
				BulletManager.Instance.Shoot(this.transform, this._enemies[0]);
			}

			this._timeout = 3f;
		}
	}
}
