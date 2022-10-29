using Common;

namespace Src {
	public sealed class App : Singleton<App> {
		private const int Index = 2;
		private static App _instance;
		private static int _scene;
		private static readonly int[] WaveList = { 2, 4 };
		private static readonly int[] EnemyList = { 4, 2 };
		private static readonly float[] EnemyListTimeout = { 0.25f, 0.25f };
		private static readonly int[] TowerList = { 5, 5 };
		private static readonly float[] WaveListTimeout = { 0.5f, 0.5f };
		private static int _level;
		public readonly int Enemies;
		public readonly float EnemiesTimeout;
		public readonly int Towers;
		public readonly int Waves;
		public readonly float WavesTimeout;

		private App() {
			Level = 1;
			var level = Level - 1;
			this.Enemies = EnemyList[level];
			this.EnemiesTimeout = EnemyListTimeout[level];
			this.Towers = TowerList[level];
			this.Waves = WaveList[level];
			this.WavesTimeout = WaveListTimeout[level];
		}

		public static int Level {
			get => _level;
			set {
				_level = value;
				LevelIndex = value + Index - 1;
			}
		}

		public static int LevelIndex { get; private set; }
	}
}
