using System.Collections;
using Common;
using GameScene;
using UnityEngine;

namespace App.Enemy {
	public class EnemyManager : Singleton {
		[SerializeField] private Transform spawnStartTransform;
		[SerializeField] private Transform spawnEndTransform;
		[SerializeField] private GameObject enemyGameObject;
		private readonly int[] _enemies = { 3, 2 };
		private readonly int[] _waves = { 2, 3 };
		private Main _main;
		private Transform _transform;
		private int Waves => _waves[_main.Level - 1];
		private int Enemies => _enemies[_main.Level - 1];
		public EnemyManager Instance { get; set; }

		public void Awake() {
			// Instance = Helper.SingletonInstance<EnemyManager>(this, Instance);
			Instance = GetInstance<EnemyManager>();
			_main = Helper.FindComponent<Main>("Main");
			_transform = transform;
		}

		private void Start() {
			StartCoroutine(SpawnWaves());
		}

		private IEnumerator SpawnWaves() {
			for (var i = 0; i < Waves; i++) {
				StartCoroutine(SpawnWave());
				yield return new WaitForSeconds(1.5f);
			}
		}

		private IEnumerator SpawnWave() {
			for (var i = 0; i < Enemies; i++) {
				var enemy = Instantiate(enemyGameObject, spawnStartTransform.position, spawnStartTransform.rotation, _transform);
				enemy.GetComponent<Enemy>().Go(spawnEndTransform.position);
				yield return new WaitForSeconds(0.25f);
			}
		}
	}
}
