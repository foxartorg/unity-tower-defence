using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Enemy {
	public sealed class EnemyManager : MonoInstance<EnemyManager> {
		[SerializeField] private GameObject enemyPrefab;
		[SerializeField] private Transform spawnEnd;
		[SerializeField] private Transform spawnStart;
		private readonly List<GameObject> _enemyList;

		private EnemyManager() {
			this._enemyList = new List<GameObject>();
		}

		public void CreateEnemy() {
			var enemy = Instantiate(this.enemyPrefab, this.spawnStart.position, Quaternion.identity, this.transform);
			this._enemyList.Add(enemy);
			UserInterface.Instance.EnemyCounter(this._enemyList.Count);
		}

		public void DestroyEnemy(GameObject enemy) {
			this._enemyList.Remove(enemy);
			Destroy(enemy);
			UserInterface.Instance.EnemyCounter(this._enemyList.Count);
		}

		public Vector3 GetDestination() {
			return this.spawnEnd.position;
		}
	}
}
