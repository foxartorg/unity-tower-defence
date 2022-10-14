using System.Collections;
using UnityEngine;

namespace GameScene {
	public class Main : MonoBehaviour {
		private const int LevelIndex = 2;
		[SerializeField] public CanvasUI canvasUI;
		private int _level;
		private int Scene { get; set; }

		public int Level {
			get => this._level;
			private set {
				this._level = value;
				this.Scene = value + LevelIndex - 1;
			}
		}

		private void Awake() {
			this.canvasUI.LevelText(this.Level = 1);
			this.canvasUI.TowerCountText(0, 0);
		}

		private IEnumerator Start() {
			yield return SceneLoader.LoadScene(this.Scene);
		}

		public IEnumerator SwitchToLevel(int level) {
			yield return SceneLoader.UnloadSceneAsync(this.Scene);
			this.canvasUI.LevelText(this.Level = level);
			this.canvasUI.TowerCountText(0, 0);
			yield return SceneLoader.LoadScene(this.Scene);
		}
	}
}
