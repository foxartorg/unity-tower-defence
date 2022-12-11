using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Examples {
	public sealed class SceneManagerExample : MonoInstance<SceneManagerExample> {
		private void OnEnable() {
			SceneManager.sceneLoaded += OnEnableHook;
		}

		private void OnDisable() {
			SceneManager.sceneLoaded -= OnDisableHook;
		}

		private static void OnEnableHook(Scene scene, LoadSceneMode mode) {
			Debug.Log($"OnEnable: {scene.name}[{scene.buildIndex}] {mode}");
		}

		private static void OnDisableHook(Scene scene, LoadSceneMode mode) {
			Debug.Log($"OnDisable: {scene.name}[{scene.buildIndex}] {mode}");
		}

		private static IEnumerator LoadScene(int scene, bool additive = true) {
			var async = SceneManager.LoadSceneAsync(scene, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);
			while (!async.isDone) {
				yield return null;
			}
		}

		private static IEnumerator UnloadScene(int scene) {
			var async = SceneManager.UnloadSceneAsync(scene);
			while (!async.isDone) {
				yield return null;
			}
		}
	}
}
