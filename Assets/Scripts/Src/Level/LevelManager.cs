using Common;
using Scenes.GameScene;
using UnityEngine;

namespace Src.Level {
	public class LevelManager : MonoBehaviourSingleton<LevelManager> {
		[SerializeField] private int level;

		private void Awake() {
			EventSystem.Autoload = false;
			App.CurrentLevelSceneIndex = App.GetLevelSceneIndex(this.level);
		}

		private void Start() {
			App.Level = this.level;
			if (Camera.main) {
				return;
			}

			this.StartCoroutine(SceneHelper.Load(App.GameSceneIndex, true));
			this.StartCoroutine(SceneHelper.SetActive(App.GameSceneIndex));
		}
	}
}
