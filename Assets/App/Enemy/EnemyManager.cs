using System.Collections;
using Common;
using GameScene;
using UnityEngine;

namespace App.Enemy {
	public class EnemyManager : Manager {
		[SerializeField] private Transform spawnStartTransform;
		[SerializeField] private Transform spawnEndTransform;
		[SerializeField] private GameObject enemyGameObject;
		private readonly int[] _enemies = { 3, 2 };
		private readonly int[] _waves = { 2, 3 };
		private Main _main;
		private Transform _transform;
		private int Waves => this._waves[this._main.Level - 1];
		private int Enemies => this._enemies[this._main.Level - 1];
		public static EnemyManager Instance { get; private set; }
		private int _counter;


		public void Awake() {
			Instance = this.SingleInstance<EnemyManager>(this, Instance);
			this._main = Helper.FindComponent<Main>("Main");

			this._transform = this.transform;
		}

		private void Start() {
			this.StartCoroutine(this.SpawnWaves());
		}

		private IEnumerator SpawnWaves() {
			for (var i = 0; i < this.Waves; i++) {
				this.StartCoroutine(this.SpawnWave());
				yield return new WaitForSeconds(1.5f);
			}
		}

		private IEnumerator SpawnWave() {
			for (var i = 0; i < this.Enemies; i++) {
				var enemy = Instantiate(this.enemyGameObject, this.spawnStartTransform.position,
					this.spawnStartTransform.rotation, this._transform);
				enemy.GetComponent<Enemy>().Go(this.spawnEndTransform.position);
				this._main.canvasUI.EnemyCounterText(++this._counter);
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
