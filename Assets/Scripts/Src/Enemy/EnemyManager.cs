using System.Collections;
using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Enemy {
	public sealed class EnemyManager : MonoComponent<EnemyManager> {
		[SerializeField] private GameObject enemyPrefab;
		[SerializeField] private Transform spawnEnd;
		[SerializeField] private Transform spawnStart;
		private List<GameObject> _enemyList;

		private void Awake() {
			this._enemyList = new List<GameObject>();
		}

		private static Enemy GetEnemy(GameObject enemy) {
			return enemy.GetComponent<Enemy>();
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
			GetEnemy(enemy).Delete();
		}

		public void MoveEnemy(GameObject enemy) {
			GetEnemy(enemy).MoveTo(this.spawnEnd.position);
		}
	}
}
