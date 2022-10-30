using Common;
using UnityEngine;

namespace Src.Level {
	public sealed class LevelManager : MonoBehaviourSingleton<LevelManager> {
		[SerializeField] private int level;

		private void Start() {
			if (Camera.main) {
				return;
			}

			App.Level = this.level;
			this.StartCoroutine(SceneHelper.Load(App.GameSceneIndex, true));
			this.StartCoroutine(SceneHelper.SetActive(App.GameSceneIndex));
		}
	}
}
