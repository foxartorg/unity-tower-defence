using Common;
using Src.Enemy;
using UnityEngine;

namespace Src {
	public class App : MonoComponent<App> {
		public const int MainSceneIndex = 0;
		public const int GameSceneIndex = 1;
		private const int LevelSceneIndex = 2;
		private static readonly int[] EnemyList = { 4, 2 };
		private static readonly float[] EnemyTimeoutList = { 0.25f, 0.25f };
		private static readonly int[] TowerList = { 5, 5 };
		private static readonly int[] WaveList = { 2, 4 };
		private static readonly float[] WaveTimeoutList = { 0.5f, 0.5f };
		public static int CurrLevelScene;
		public static int PrevLevelScene;
		private static int _level;
		[SerializeField] public int level;
		public static int Enemies => EnemyList[_level - 1];
		public static float EnemiesTimeout => EnemyTimeoutList[_level - 1];
		public static int Towers => TowerList[_level - 1];
		public static int Waves => WaveList[_level - 1];
		public static float WavesTimeout => WaveTimeoutList[_level - 1];

		public static int Level {
			get => _level;
			set {
				_level = value;
				CurrLevelScene = LevelSceneIndex + value - 1;
				PrevLevelScene = LevelSceneIndex + value - 1;
			}
		}

		private void Awake() {
			Application.targetFrameRate = 60;
		}

		private void Start() {
			if (Camera.main) {
				this.Run();
				return;
			}

			Level = this.level;
			this.StartCoroutine(SceneHelper.Load(GameSceneIndex, true));
			this.StartCoroutine(SceneHelper.SetActive(GameSceneIndex));
			this.Run();
		}

		private void Run() {
			this.StartCoroutine(EnemyManager.Instance.Spawn());
		}
	}
}
