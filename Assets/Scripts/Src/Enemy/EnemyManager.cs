using System.Collections;
using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Enemy {
	public sealed class EnemyManager : MonoBehaviourSingleton<EnemyManager> {
		[SerializeField] private GameObject enemyPrefab;
		[SerializeField] private Transform spawnStart;
		[SerializeField] private Transform spawnEnd;
		private List<GameObject> _enemyList;

		private void Awake() {
			this._enemyList = new List<GameObject>();
		}

		public IEnumerator Spawn() {
			for (var i = 0; i < App.Waves; i++) {
				for (var j = 0; j < App.Enemies; j++) {
					this.CreateEnemy();
					yield return new WaitForSeconds(App.EnemiesTimeout);
				}

				yield return new WaitForSeconds(App.WavesTimeout);
			}
		}

		private void CreateEnemy() {
			var enemy = Enemy.Add(this.enemyPrefab, this.transform, this.spawnStart);
			this._enemyList.Add(enemy);
			CanvasUI.Instance.EnemyCounter(this._enemyList.Count);
		}

		public void DestroyEnemy(GameObject enemy) {
			this._enemyList.Remove(enemy);
			CanvasUI.Instance.EnemyCounter(this._enemyList.Count);
			Enemy.Delete(enemy);
		}

		public void MoveEnemy() {
			Enemy.Instance.MoveTo(this.spawnEnd.position);
		}
	}
}
