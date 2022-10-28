using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Src {
	public sealed class App : Singleton<App> {
		private static int _scene;
		private static readonly int[] WaveList = { 2, 4 };
		private static readonly int[] EnemyList = { 4, 2 };
		private static readonly float[] EnemyListTimeout = { 0.25f, 0.25f };
		private static readonly int[] TowerList = { 5, 5 };
		private static readonly float[] WaveListTimeout = { 0.5f, 0.5f };
		public int enemies;
		public float enemiesTimeout;
		public int towers;
		public int waves;
		public float wavesTimeout;

		private void Awake() {
			var scene = SceneManager.GetActiveScene();
			Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
			Application.targetFrameRate = 60;
			var level = Main.Level - 1;
			Debug.Log($"APP {Main.Level} {level}");
			this.enemies = EnemyList[level];
			this.enemiesTimeout = EnemyListTimeout[level];
			this.towers = TowerList[level];
			this.waves = WaveList[level];
			this.wavesTimeout = WaveListTimeout[level];
		}

		private IEnumerator Start() {
			if (Main.Level == 0) {
				// yield return Main.LoadGameScene(2);
				yield return null;
			}
		}
	}
}
