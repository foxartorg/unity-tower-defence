using UnityEngine;

namespace Src {
	public sealed class App : MonoBehaviour {
		public static int CurrentLevelSceneIndex;
		private static readonly int[] EnemyList = { 4, 2 };
		private static readonly float[] EnemyTimeoutList = { 0.25f, 0.25f };
		private static readonly int[] TowerList = { 5, 5 };
		private static readonly int[] WaveList = { 2, 4 };
		private static readonly float[] WaveTimeoutList = { 0.5f, 0.5f };
		private static int _level;
		private static int _index;
		public static int Enemies => EnemyList[_index];
		public static float EnemiesTimeout => EnemyTimeoutList[_index];
		public static int Towers => TowerList[_index];
		public static int Waves => WaveList[_index];
		public static float WavesTimeout => WaveTimeoutList[_index];

		public static int Level {
			get => _level;
			set {
				_level = value;
				_index = _level - 1;
			}
		}

		public static int MainSceneIndex => 0;
		public static int GameSceneIndex => 1;
		public static int LevelSceneIndex => 2;

		public static int GetLevelSceneIndex(int level) {
			return LevelSceneIndex + level - 1;
		}
	}
}
