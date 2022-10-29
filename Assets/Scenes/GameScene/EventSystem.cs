using System.Collections;
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
			this.menuButton.onClick.AddListener(() => this.StartCoroutine(SceneHelper.Load(App.MainSceneIndex)));
			this.level1Button.onClick.AddListener(() => this.StartCoroutine(LoadLevel(1)));
			this.level2Button.onClick.AddListener(() => this.StartCoroutine(LoadLevel(2)));
			if (Autoload) {
				this.StartCoroutine(SceneHelper.Load(App.LevelSceneIndex, true));
			}
		}

		private static IEnumerator LoadLevel(int level) {
			// if (SceneHelper.IsLoaded(App.CurrentLevelSceneIndex)) { }
			yield return SceneHelper.Unload(App.CurrentLevelSceneIndex);
			App.CurrentLevelSceneIndex = App.GetLevelSceneIndex(level);
			yield return SceneHelper.Load(App.CurrentLevelSceneIndex, true);
			CanvasUI.Instance.Level(App.Level);
		}
	}
}
