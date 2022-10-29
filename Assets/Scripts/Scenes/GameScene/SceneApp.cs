using System.Collections;
using Common;
using Src;
using UnityEngine;

namespace Scenes.GameScene {
	public sealed class SceneApp : Singleton<SceneApp> {
		private int _scene;

		private IEnumerator Start() {
			// yield return Main.SwitchToLevel(1);
			Debug.Log($"SCENE {App.Level}");
			if (App.Level == 0) {
				yield return Main.SwitchToLevel(1);
			}
			// yield return Main.SwitchToLevel(Main.Level);
		}
	}
}
