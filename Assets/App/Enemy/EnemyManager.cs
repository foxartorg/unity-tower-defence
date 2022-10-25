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
		public bool hasEnemies;
		private int _counter;

		private void Start() {
			this.StartCoroutine(this.SpawnWaves());
		}

		private IEnumerator SpawnWaves() {
			for (var i = 0; i < Main.Instance.Waves; i++) {
				this.StartCoroutine(this.SpawnWave());
				yield return new WaitForSeconds(5f);
			}
		}

		private IEnumerator SpawnWave() {
			for (var i = 0; i < Main.Instance.Enemies; i++) {
				var enemyGameObject = Instantiate(this.enemyPrefab, this.spawnStart.position, this.spawnStart.rotation, this.transform);
				var enemyComponent = enemyGameObject.GetComponent<Enemy>();
				enemyComponent.HookCreate += () => {
					this.hasEnemies = true;
					this.enemyList.Add(enemyComponent.gameObject);
					CanvasUI.Instance.EnemyCounterText(++this._counter);
					CanvasUI.Instance.DummyText(this.enemyList.Count.ToString());
				};
				enemyComponent.HookCreate += () => {
					// Debug.Log("another hook");
				};
				enemyComponent.HookDestroy += context => {
					this.enemyList.Remove(enemyComponent.gameObject);
					Destroy(context);
					if (this.enemyList.Count == 0) {
						this.hasEnemies = false;
					}

					CanvasUI.Instance.EnemyCounterText(--this._counter);
					CanvasUI.Instance.DummyText(this.enemyList.Count.ToString());
				};
				enemyComponent.Go(this.spawnEnd.position);
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
