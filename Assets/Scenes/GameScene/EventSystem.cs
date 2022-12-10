using Common;
using Src;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameScene {
	public sealed class EventSystem : MonoBehaviour {
		[SerializeField] private Button menuButton;
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;

		private void Awake() {
			if (App.Level == 0) {
				this.LoadLevelScene(1);
			} else {
				CanvasUI.Instance.Level(App.Level);
			}
		}

		private void Start() {
			this.menuButton.onClick.AddListener(this.LoadMainScene);
			this.level1Button.onClick.AddListener(() => this.LoadLevelScene(1));
			this.level2Button.onClick.AddListener(() => this.LoadLevelScene(2));
		}

		private void LoadMainScene() {
			App.Level = 0;
			this.StartCoroutine(SceneHelper.Load(App.MainSceneIndex));
		}

		private void LoadLevelScene(int level) {
			// Debug.Log($"UNLOAD {LevelManager.PrevLevelScene}");
			if (SceneHelper.IsLoaded(App.PrevLevelScene)) {
				this.StartCoroutine(SceneHelper.Unload(App.PrevLevelScene));
			}

			App.Level = level;
			// Debug.Log($"LOAD {LevelManager.CurrLevelScene}");
			this.StartCoroutine(SceneHelper.Load(App.CurrLevelScene, true));
			CanvasUI.Instance.Level(level);
		}
	}
}
