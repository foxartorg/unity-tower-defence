using System.Collections;
using UnityEngine.SceneManagement;

namespace Common {
	public static class SceneHelper {
		public static Scene Get(int index) {
			return SceneManager.GetSceneByBuildIndex(index);
		}

		public static IEnumerator SetActive(int index) {
			var scene = SceneManager.GetSceneByBuildIndex(index);
			while (!scene.isLoaded) {
				yield return null;
			}

			SceneManager.SetActiveScene(scene);
		}

		public static bool IsLoaded(int index) {
			return SceneManager.GetSceneByBuildIndex(index).isLoaded;
		}

		public static IEnumerator Load(int index, bool append = false) {
			var async = SceneManager.LoadSceneAsync(index, append ? LoadSceneMode.Additive : LoadSceneMode.Single);
			while (!async.isDone) {
				yield return null;
			}
		}

		public static IEnumerator Unload(int index) {
			var async = SceneManager.UnloadSceneAsync(index);
			while (!async.isDone) {
				yield return null;
			}
		}
	}
}
