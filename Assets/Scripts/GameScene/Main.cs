using System.Collections;
using UnityEngine;

namespace GameScene {
	public sealed class Main : SceneSingleton<Main> {
		private const int LevelIndex = 2;
		private readonly int[] _enemies = { 4, 2 };
		private readonly float[] _enemiesTimeout = { 0.25f, 0.25f };
		private readonly int[] _towers = { 5, 5 };
		private readonly int[] _waves = { 2, 4 };
		private readonly float[] _wavesTimeout = { 1.5f, 1.5f };
		private int _level;
		private int _scene;

		private int Level {
			set {
				this._level = value;
				this._scene = value + LevelIndex - 1;
			}
		}

		public int Enemies => this._enemies[this._level - 1];
		public float EnemiesTimeout => this._enemiesTimeout[this._level - 1];
		public int Towers => this._towers[this._level - 1];
		public int Waves => this._waves[this._level - 1];
		public float WavesTimeout => this._wavesTimeout[this._level - 1];

		private void Awake() {
			Application.targetFrameRate = 60;
			CanvasUI.Instance.Level(this.Level = 1);
			CanvasUI.Instance.EnemyCounter(0);
			CanvasUI.Instance.TowerCount(0, 0);
		}

		private IEnumerator Start() {
			yield return SceneLoader.LoadScene(this._scene);
		}

		public IEnumerator SwitchToLevel(int level) {
			yield return SceneLoader.UnloadSceneAsync(this._scene);
			CanvasUI.Instance.Level(this.Level = level);
			CanvasUI.Instance.EnemyCounter(0);
			CanvasUI.Instance.TowerCount(0, 0);
			yield return SceneLoader.LoadScene(this._scene);
		}
	}
}
