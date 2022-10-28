using Common;
using UnityEngine;

namespace Src {
	public sealed class App : Singleton<App> {
		private static int _scene;
		private static readonly int[] WaveList = { 2, 4 };
		private static readonly int[] EnemyList = { 4, 2 };
		private static readonly float[] EnemyListTimeout = { 0.25f, 0.25f };
		private static readonly int[] TowerList = { 5, 5 };
		private static readonly float[] WaveListTimeout = { 0.5f, 0.5f };
		private readonly int _level = Main.Level;
		public int Enemies => EnemyList[this._level - 1];
		public float EnemiesTimeout => EnemyListTimeout[this._level - 1];
		public int Towers => TowerList[this._level - 1];
		public int Waves => WaveList[this._level - 1];
		public float WavesTimeout => WaveListTimeout[this._level - 1];

		private void Awake() {
			Application.targetFrameRate = 60;
			// CanvasUI.Instance.Level(Level = 1);
			// CanvasUI.Instance.EnemyCounter(0);
			// CanvasUI.Instance.TowerCount(0, 0);
		}

		private void Start() {
			if (Main.Level < 2) {
				Debug.Log($"{Main.Level}");
				// yield return Main.LoadLevel(1);
			}
		}
	}
}
