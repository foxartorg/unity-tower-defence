using System.Collections.Generic;
using App.Bullet;
using GameScene;
using UnityEngine;

namespace App.Tower {
	public class Tower : MonoBehaviour {
		private int _counter;
		private List<GameObject> _towerEnemyList;
		private int _id;
		private LineRenderer _lr;

		private void Awake() {
			this._towerEnemyList = new List<GameObject>();
			// this._id = this._counter++;
			// Debug.Log($"ENEMY {this._id}");
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
			this.StartCoroutine(BulletManager.Instance.Shoot(this.transform));
		}

		private void OnTriggerEnter(Collider other) {
			if (!other.gameObject.CompareTag("Enemy")) {
				return;
			}

			Debug.Log($"ENEMY ENTERED!");
			this._towerEnemyList.Add(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._towerEnemyList.Count);
		}

		private void OnTriggerExit(Collider other) {
			if (!other.gameObject.CompareTag("Enemy")) {
				return;
			}

			Debug.Log("ENEMY EXIT!");
			this._towerEnemyList.Remove(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._towerEnemyList.Count);
		}
	}
}
