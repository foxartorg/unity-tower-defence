using System.Collections;
using UnityEngine;

namespace Enemy {
	public class Manager : MonoBehaviour {
		[SerializeField] private Transform spawnStartTransform;
		[SerializeField] private Transform spawnEndTransform;
		[SerializeField] public GameObject enemyGameObject;
		private readonly int[] _enemies = { 3, 2 };
		private readonly int[] _waves = { 2, 3 };
		private Canvas _canvas;
		private Transform _transform;
		private int Waves => _waves[_canvas.Level - 1];
		private int Enemies => _enemies[_canvas.Level - 1];

		public void Awake() {
			_transform = transform;
			_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
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
