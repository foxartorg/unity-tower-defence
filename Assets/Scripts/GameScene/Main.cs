using System.Collections;
using UnityEngine;

namespace GameScene {
	public class Main : MonoBehaviour {
		private const int LevelIndex = 2;
		[SerializeField] public CanvasUi canvasUi;
		[SerializeField] private SceneLoader sceneLoader;
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
			canvasUi.LevelText(Level = 1);
			canvasUi.TowerCountText(0);
		}

		private IEnumerator Start() {
			yield return SceneLoader.LoadScene(Scene);
		}

		public IEnumerator SwitchToLevel(int level) {
			yield return SceneLoader.UnloadSceneAsync(Scene);
			canvasUi.LevelText(Level = level);
			canvasUi.TowerCountText(0);
			yield return SceneLoader.LoadScene(Scene);
		}
	}
}
