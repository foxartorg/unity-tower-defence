using System.Collections;
using Common;
using UnityEngine;

namespace GameScene {
	public sealed class Scene : Singleton<Scene> {
		private int _scene;

		private IEnumerator Start() {
			// yield return Main.SwitchToLevel(1);
			Debug.Log($"SCENE {Main.Level}");
			if (Main.Level == 0) {
				yield return Main.SwitchToLevel(1);
			}
			// yield return Main.SwitchToLevel(Main.Level);
		}
	}
}
