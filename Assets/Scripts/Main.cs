using System.Collections;
using Scenes.GameScene;
using Src;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Main {
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

	private static void UpdateCanvasUI(int level) {
		CanvasUI.Instance.Level(level);
		CanvasUI.Instance.EnemyCounter(0);
		CanvasUI.Instance.TowerCount(0, 0);
	}

	public static IEnumerator LoadMainScene() {
		App.Level = 0;
		yield return LoadScene(0, false);
	}

	public static IEnumerator LoadGameScene(int level = 1) {
		App.Level = level;
		yield return LoadScene(1, false);
	}

	public static IEnumerator SwitchToLevel(int level) {
		Debug.Log($"SwitchToLevel {level}");
		var prev = App.LevelIndex;
		App.Level = level;
		if (SceneManager.GetSceneByBuildIndex(prev).isLoaded) {
			yield return UnloadScene(prev);
		}

		yield return LoadScene(App.LevelIndex);
		UpdateCanvasUI(level);
	}
}
