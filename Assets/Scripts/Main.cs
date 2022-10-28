using System.Collections;
using Common;
using GameScene;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public sealed class Main : Singleton<Main> {
	private const int Index = 2;
	private static int _level;
	private static int _scene;

	public static int Level {
		get => _level;
		private set {
			_level = value;
			_scene = value + Index - 1;
		}
	}

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

	public static IEnumerator SwitchToMenu() {
		yield return LoadScene(0, false);
	}

	public static IEnumerator SwitchToGame() {
		yield return LoadScene(1, false);
	}

	public static IEnumerator LoadLevel(int level) {
		Level = level;
		yield return LoadScene(_scene);
		UpdateCanvasUI(level);
	}

	public static IEnumerator SwitchToLevel(int level) {
		yield return UnloadScene(_scene);
		yield return LoadLevel(level);
	}
}
