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
		public List<Transform> enemyTransform;
		private int _counter;

		private void Start() {
			this.StartCoroutine(this.SpawnWaves());
		}

		private IEnumerator SpawnWaves() {
			for (var i = 0; i < Main.Instance.Waves; i++) {
				this.StartCoroutine(this.SpawnWave());
				yield return new WaitForSeconds(1.5f);
			}
		}

		private IEnumerator SpawnWave() {
			for (var i = 0; i < Main.Instance.Enemies; i++) {
				var enemyGameObject = Instantiate(this.enemyPrefab, this.spawnStart.position, this.spawnStart.rotation, this.transform);
				var enemyComponent = enemyGameObject.GetComponent<Enemy>();
				enemyComponent.OnCreate += () => CanvasUI.Instance.EnemyCounterText(++this._counter);
				enemyComponent.OnDestroy += context => {
					CanvasUI.Instance.EnemyCounterText(--this._counter);
					Destroy(context);
				};
				enemyComponent.Go(this.spawnEnd.position);
				this.enemyTransform.Add(enemyComponent.transform);
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
