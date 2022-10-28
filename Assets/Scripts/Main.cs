using System.Collections;
using GameScene;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public sealed class Main {
	// public static Instance { get; private set; }
	private const int Index = 2;
	private static int _level;

	public static int Level {
		get => _level;
		private set {
			_level = value;
			LevelIndex = value + Index - 1;
		}
	}

	public static int LevelIndex { get; private set; }

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

	private static void UpdateCanvasUI(int level) {
		CanvasUI.Instance.Level(level);
		CanvasUI.Instance.EnemyCounter(0);
		CanvasUI.Instance.TowerCount(0, 0);
	}

	public static IEnumerator LoadMainScene() {
		Level = 0;
		yield return LoadScene(0, false);
	}

	public static IEnumerator LoadGameScene(int level = 1) {
		Level = level;
		yield return LoadScene(1, false);
	}

	public static IEnumerator SwitchToLevel(int level) {
		Debug.Log($"SwitchToLevel {level}");
		var prev = LevelIndex;
		Level = level;
		if (SceneManager.GetSceneByBuildIndex(prev).isLoaded) {
			yield return UnloadScene(prev);
		}

		yield return LoadScene(LevelIndex);
		UpdateCanvasUI(level);
	}
}
