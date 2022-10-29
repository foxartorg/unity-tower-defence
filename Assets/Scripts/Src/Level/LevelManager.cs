using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Level {
	public class LevelManager : MonoBehaviourSingleton<LevelManager> {
		[SerializeField] private int level;

		private void Awake() {
			EventSystem.Autoload = false;
			App.CurrentLevelSceneIndex = App.GetLevelSceneIndex(App.Level = this.level);
		}

		private void Start() {
			if (Camera.main) {
				return;
			}

			this.StartCoroutine(SceneHelper.Load(App.GameSceneIndex, true));
			this.StartCoroutine(SceneHelper.SetActive(App.GameSceneIndex));
		}
	}
}
