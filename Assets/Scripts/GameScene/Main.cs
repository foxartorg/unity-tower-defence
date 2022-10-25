using System.Collections;

namespace GameScene {
	public sealed class Main : SceneSingleton<Main> {
		private const int LevelIndex = 2;
		private readonly int[] _enemies = { 10, 10 };
		private readonly int[] _towers = { 3, 5 };
		private readonly int[] _waves = { 1, 2 };
		private int _level;
		private int _scene;

		private int Level {
			set {
				this._level = value;
				this._scene = value + LevelIndex - 1;
			}
		}

		public int Health => 100;
		public int Waves => this._waves[this._level - 1];
		public int Enemies => this._enemies[this._level - 1];
		public int Towers => this._towers[this._level - 1];

		private void Awake() {
			CanvasUI.Instance.LevelText(this.Level = 1);
			CanvasUI.Instance.EnemyCounterText(0);
			CanvasUI.Instance.TowerCountText(0, 0);
		}

		private IEnumerator Start() {
			yield return SceneLoader.LoadScene(this._scene);
		}

		public IEnumerator SwitchToLevel(int level) {
			yield return SceneLoader.UnloadSceneAsync(this._scene);
			CanvasUI.Instance.LevelText(this.Level = level);
			CanvasUI.Instance.EnemyCounterText(0);
			CanvasUI.Instance.TowerCountText(0, 0);
			yield return SceneLoader.LoadScene(this._scene);
		}
	}
}
