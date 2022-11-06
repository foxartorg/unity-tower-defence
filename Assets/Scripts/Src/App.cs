using UnityEngine;

namespace Src {
	public sealed class App : MonoBehaviour {
		private static readonly int[] EnemyList = { 4, 2 };
		private static readonly float[] EnemyTimeoutList = { 0.25f, 0.25f };
		private static readonly int[] TowerList = { 5, 5 };
		private static readonly int[] WaveList = { 2, 4 };
		private static readonly float[] WaveTimeoutList = { 0.5f, 0.5f };
		private static int _level;
		private static int _levelIndex;
		public static int LevelScene { get; private set; }
		public static int Enemies => EnemyList[_level - 1];
		public static float EnemiesTimeout => EnemyTimeoutList[_level - 1];
		public static int Towers => TowerList[_level - 1];
		public static int Waves => WaveList[_level - 1];
		public static float WavesTimeout => WaveTimeoutList[_level - 1];

		public static int Level {
			get => _level;
			set {
				_level = value;
				LevelScene = LevelSceneIndex + value - 1;
			}
		}

		public static int MainSceneIndex => 0;
		public static int GameSceneIndex => 1;
		public static int LevelSceneIndex => 2;
	}
}
