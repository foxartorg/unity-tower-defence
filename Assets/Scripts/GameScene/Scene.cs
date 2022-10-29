using System.Collections;
using Common;

namespace GameScene {
	public sealed class Scene : Singleton<Scene> {
		private int _scene;

		private IEnumerator Start() {
			yield return Main.LoadLevel(1);
		}
	}
}
