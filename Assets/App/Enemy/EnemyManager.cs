using System.Collections;
using System.Collections.Generic;
using Common;
using GameScene;
using UnityEngine;

namespace App.Enemy {
	public class EnemyManager : Manager {
		public List<Transform> enemyTransform;
		[SerializeField] private Transform spawnStart;
		[SerializeField] private Transform spawnEnd;
		[SerializeField] private GameObject enemy;
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
				var enemyGameObject = Instantiate(this.enemy, this.spawnStart.position, this.spawnStart.rotation, this.transform);
				var enemyComponent = enemyGameObject.GetComponent<Enemy>();
				enemyComponent.OnCreate += () => Main.CanvasUI.EnemyCounterText(++this._counter);
				enemyComponent.OnDestroy += context => {
					Main.CanvasUI.EnemyCounterText(--this._counter);
					Destroy(context);
				};
				enemyComponent.Go(this.spawnEnd.position);
				this.enemyTransform.Add(enemyComponent.transform);
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
