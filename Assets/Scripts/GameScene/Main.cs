using System.Collections;
using UnityEngine;

namespace GameScene {
	public class Main : MonoBehaviour {
		private const int LevelIndex = 2;
		[SerializeField] public CanvasUI canvasUI;
		private int _level;
		private int Scene { get; set; }

		public int Level {
			get => _level;
			private set {
				_level = value;
				Scene = value + LevelIndex - 1;
			}
		}

		private void Awake() {
			canvasUI.LevelText(Level = 1);
			canvasUI.TowerCountText(0);
		}

		private IEnumerator Start() {
			yield return SceneLoader.LoadScene(Scene);
		}

		public IEnumerator SwitchToLevel(int level) {
			yield return SceneLoader.UnloadSceneAsync(Scene);
			canvasUI.LevelText(Level = level);
			canvasUI.TowerCountText(0);
			yield return SceneLoader.LoadScene(Scene);
		}
	}
}
