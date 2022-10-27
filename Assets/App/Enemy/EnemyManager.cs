using System.Collections;
using System.Collections.Generic;
using Common;
using GameScene;
using UnityEngine;

namespace App.Enemy {
	public class EnemyManager : Singleton<EnemyManager> {
		[SerializeField] private Transform spawnStart;
		[SerializeField] private Transform spawnEnd;
		[SerializeField] private GameObject enemyPrefab;
		public List<GameObject> enemyList;
		private int _counter;

		private async void Start() {
			this.StartCoroutine(this.Spawn());
		}

		private IEnumerator Spawn() {
			for (var i = 0; i < Main.Instance.Waves; i++) {
				for (var j = 0; j < Main.Instance.Enemies; j++) {
					var enemy = Instantiate(this.enemyPrefab, this.spawnStart.position, this.spawnStart.rotation, this.transform);
					this.CreateEnemy(enemy);
					yield return new WaitForSeconds(Main.Instance.EnemiesTimeout);
				}

				yield return new WaitForSeconds(Main.Instance.WavesTimeout);
			}
		}

		private void CreateEnemy(GameObject enemy) {
			var enemyComponent = enemy.GetComponent<Enemy>();
			CanvasUI.Instance.EnemyCounter(++this._counter);
			this.enemyList.Add(enemy);
			enemyComponent.Create(this.spawnEnd.position);
		}

		public void DestroyEnemy(GameObject enemy) {
			CanvasUI.Instance.EnemyCounter(--this._counter);
			this.enemyList.Remove(enemy);
			Destroy(enemy);
		}
	}
}
