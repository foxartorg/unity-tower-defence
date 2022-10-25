using System.Collections;

namespace GameScene {
	public sealed class Main : SceneSingleton<Main> {
		private const int LevelIndex = 2;
		private readonly int[] _enemies = { 2, 50 };
		private readonly int[] _towers = { 5, 5 };
		private readonly int[] _waves = { 2, 2 };
		private int _level;
		private int _scene;

		private int Level {
			set {
				this._level = value;
				this._scene = value + LevelIndex - 1;
			}
		}

		public int Waves => this._waves[this._level - 1];
		public int Enemies => this._enemies[this._level - 1];
		public int Towers => this._towers[this._level - 1];

		private void Awake() {
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
