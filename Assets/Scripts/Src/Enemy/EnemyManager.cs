using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Src.Enemy {
	public sealed class EnemyManager : MonoBehaviourSingleton<EnemyManager> {
		[SerializeField] private List<Transform> start;
		[SerializeField] private List<Transform> stop = new();
		[SerializeField] private Transform spawnStart;
		[SerializeField] private Transform spawnEnd;
		[SerializeField] private GameObject enemyPrefab;
		private readonly List<GameObject> _enemyList;
		private int _counter;

		private EnemyManager() {
			this._enemyList = new List<GameObject>();
			this.start = new List<Transform>();
		}

		private void Awake() {
			// Helper.FindComponent<>(spawnStart);
		}

		private void Start() {
			this.StartCoroutine(this.Spawn());
		}

		private IEnumerator Spawn() {
			for (var i = 0; i < App.Waves; i++) {
				for (var j = 0; j < App.Enemies; j++) {
					var enemy = Instantiate(this.enemyPrefab, this.spawnStart.position, this.spawnStart.rotation, this.transform);
					this.CreateEnemy(enemy);
					yield return new WaitForSeconds(App.EnemiesTimeout);
				}

				yield return new WaitForSeconds(App.WavesTimeout);
			}
		}

		private void CreateEnemy(GameObject enemy) {
			// CanvasUI.Instance.EnemyCounter(++this._counter);
			enemy.GetComponent<Enemy>().Create(this.spawnEnd.position);
			this._enemyList.Add(enemy);
		}

		public void DestroyEnemy(GameObject enemy) {
			// CanvasUI.Instance.EnemyCounter(--this._counter);
			Destroy(enemy);
			this._enemyList.Remove(enemy);
		}
	}
}
