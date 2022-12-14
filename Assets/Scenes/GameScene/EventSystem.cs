using Common;
using Src;

namespace Scenes.GameScene {
	public sealed class EventSystem : MonoInstance<EventSystem> {
		private void Awake() {
			if (App.Level == 0) {
				this.LoadLevelScene(1);
			} else {
				UserInterface.Instance.Level(App.Level);
			}
		}

		public void LoadMainScene() {
			App.Level = 0;
			this.StartCoroutine(SceneHelper.Load(App.MainSceneIndex));
		}

		public void LoadLevelScene(int level) {
			// Debug.Log($"UNLOAD {LevelManager.PrevLevelScene}");
			if (SceneHelper.IsLoaded(App.PrevLevelScene)) {
				this.StartCoroutine(SceneHelper.Unload(App.PrevLevelScene));
			}

			App.Level = level;
			// Debug.Log($"LOAD {LevelManager.CurrLevelScene}");
			this.StartCoroutine(SceneHelper.Load(App.CurrLevelScene, true));
			UserInterface.Instance.Level(level);
		}
	}
}
