using Common;
using UnityEngine;

namespace Src {
	public class App : MonoBehaviourSingleton<App> {
		[SerializeField] private int level;
		private readonly int[] _enemyList = { 4, 2 };
		private readonly float[] _enemyTimeoutList = { 0.25f, 0.25f };
		private readonly int _gameSceneIndex;
		private readonly int _levelSceneIndex;
		private readonly int _mainSceneIndex;
		private readonly int[] _towerList = { 5, 5 };
		private readonly int[] _waveList = { 2, 4 };
		private readonly float[] _waveTimeoutList = { 0.5f, 0.5f };
		private int _currLevelScene;
		private int _prevLevelScene;

		private App() {
			Autoload = false;
			this._mainSceneIndex = 0;
			this._gameSceneIndex = 1;
			this._levelSceneIndex = 2;
		}

		public int Enemies => this._enemyList[this.level - 1];
		public float EnemiesTimeout => this._enemyTimeoutList[this.level - 1];
		public int Towers => this._towerList[this.level - 1];
		public int Waves => this._waveList[this.level - 1];
		public float WavesTimeout => this._waveTimeoutList[this.level - 1];
		public static bool Autoload { set; get; }

		private int Level {
			get => this.level;
			set {
				this.level = value;
				this._currLevelScene = this._levelSceneIndex + value - 1;
				this._prevLevelScene = this._levelSceneIndex + value - 1;
			}
		}

		private void Awake() {
			Application.targetFrameRate = 60;
		}

		private void Start() {
			Debug.Log($"APP {this.level}");
			if (Camera.main) {
				Autoload = false;
				// this.LoadLevelScene(1);
				Debug.Log("XXX");
				return;
			}

			this.Level = this.level;
			this.StartCoroutine(SceneHelper.Load(this._gameSceneIndex, true));
			this.StartCoroutine(SceneHelper.SetActive(this._gameSceneIndex));
		}

		public void LoadMainScene() {
			this.StartCoroutine(SceneHelper.Load(this._mainSceneIndex));
		}

		public void LoadGameScene() {
			this.StartCoroutine(SceneHelper.Load(this._gameSceneIndex));
		}

		public void LoadLevelScene(int index) {
			if (SceneHelper.IsLoaded(this._prevLevelScene)) {
				this.StartCoroutine(SceneHelper.Unload(this._prevLevelScene));
			}

			this.Level = index;
			this.StartCoroutine(SceneHelper.Load(this._currLevelScene, true));
		}
	}
}
