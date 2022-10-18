using System.Collections;
using Common;
using UnityEngine;

namespace GameScene {
	public sealed class Main : Manager {
		private const int LevelIndex = 2;
		public static CanvasUI CanvasUI;
		[SerializeField] public CanvasUI canvasUI;
		private readonly int[] _enemies = { 2, 3 };
		private readonly int[] _towers = { 3, 5 };
		private readonly int[] _waves = { 1, 2 };
		private int _level;
		private int Scene { get; set; }
		public static Main Instance { get; private set; }

		private int Level {
			set {
				this._level = value;
				this.Scene = value + LevelIndex - 1;
			}
		}

		public int Waves => this._waves[this._level - 1];
		public int Enemies => this._enemies[this._level - 1];
		public int Towers => this._towers[this._level - 1];

		private void Awake() {
			Instance = this.SingleInstance<Main>(this, Instance);
			CanvasUI = this.canvasUI;
			this.canvasUI.LevelText(this.Level = 1);
			this.canvasUI.EnemyCounterText(0);
			this.canvasUI.TowerCountText(0, 0);
		}

		private IEnumerator Start() {
			yield return SceneLoader.LoadScene(this.Scene);
		}

		public IEnumerator SwitchToLevel(int level) {
			yield return SceneLoader.UnloadSceneAsync(this.Scene);
			this.canvasUI.LevelText(this.Level = level);
			this.canvasUI.EnemyCounterText(0);
			this.canvasUI.TowerCountText(0, 0);
			yield return SceneLoader.LoadScene(this.Scene);
		}
	}
}
