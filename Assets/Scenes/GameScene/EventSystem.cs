using Common;
using Src;

namespace Scenes.GameScene {
	public sealed class EventSystem : MonoInstance<EventSystem> {
		private void Awake() {
			if (App.Level == 0) {
				this.LoadLevelScene(1);
			} else {
				UICanvas.Instance.Level(App.Level);
			}
		}

		public void LoadMainScene() {
			App.Level = 0;
			this.StartCoroutine(SceneHelper.Load(App.MainSceneIndex));
		}

		public void LoadLevelScene(int level) {
			if (SceneHelper.IsLoaded(App.PrevLevelScene)) {
				this.StartCoroutine(SceneHelper.Unload(App.PrevLevelScene));
			}

			App.Level = level;
			this.StartCoroutine(SceneHelper.Load(App.CurrLevelScene, true));
			UICanvas.Instance.Level(level);
		}
	}
}
