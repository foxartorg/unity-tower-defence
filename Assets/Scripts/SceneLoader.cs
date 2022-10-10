using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
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

	public IEnumerator LoadScene(int scene) {
		var async = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
		while (!async.isDone) {
			yield return null;
		}
	}

	public IEnumerator UnloadSceneAsync(int scene) {
		var async = SceneManager.UnloadSceneAsync(scene);
		while (!async.isDone) {
			yield return null;
		}
	}
}
