using Common;
using Src;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameScene {
	public sealed class EventSystem : MonoBehaviour {
		public static bool Autoload = true;
		[SerializeField] private Button menuButton;
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;

		private void Awake() {
			CanvasUI.Instance.Level(App.Level);
		}

		private void Start() {
			if (Autoload) {
				this.StartCoroutine(SceneHelper.Load(App.LevelSceneIndex, true));
			}

			this.menuButton.onClick.AddListener(this.LoadMain);
			this.level1Button.onClick.AddListener(() => this.LoadLevel(1));
			this.level2Button.onClick.AddListener(() => this.LoadLevel(2));
		}

		private void LoadMain() {
			this.StartCoroutine(SceneHelper.Load(App.MainSceneIndex));
		}

		private void LoadLevel(int level) {
			// if (SceneHelper.IsLoaded(App.CurrentLevelSceneIndex)) {
			// this.StartCoroutine(SceneHelper.Unload(App.CurrentLevelSceneIndex));
			// }
			this.StartCoroutine(SceneHelper.Unload(App.CurrentLevelSceneIndex));
			App.CurrentLevelSceneIndex = App.GetLevelSceneIndex(level);
			this.StartCoroutine(SceneHelper.Load(App.CurrentLevelSceneIndex, true));
			CanvasUI.Instance.Level(App.Level);
		}
	}
}
