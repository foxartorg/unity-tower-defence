using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : MonoBehaviour {
	private void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable() {
		Debug.Log("OnDisable");
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		Debug.Log("OnSceneLoaded: " + scene.name);
	}

	public static IEnumerator LoadScene(int scene, bool additive = true) {
		var async = SceneManager.LoadSceneAsync(scene, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);
		while (!async.isDone) {
			yield return null;
		}
	}

	public static IEnumerator UnloadSceneAsync(int scene) {
		var async = SceneManager.UnloadSceneAsync(scene);
		while (!async.isDone) {
			yield return null;
		}
	}
}
