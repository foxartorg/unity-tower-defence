using System.Collections;
using UnityEngine;

public class App : MonoBehaviour {
	private const int LevelIndex = 2;
	[SerializeField] private SceneLoader sceneLoader;
	[SerializeField] private UI ui;
	private int _level;
	private int Scene { get; set; }

	public int Level {
		get => _level;
		private set {
			_level = value;
			Scene = value + LevelIndex - 1;
		}
	}

	private void Awake() {
		ui.LevelText(Level = 1);
		ui.TowerCountText(0);
		ui.EnemyCountText(0);
	}

	private IEnumerator Start() {
		yield return sceneLoader.LoadScene(Scene);
	}

	public IEnumerator SwitchToLevel(int level) {
		yield return sceneLoader.UnloadSceneAsync(Scene);
		ui.LevelText(Level = level);
		ui.TowerCountText(0);
		ui.EnemyCountText(0);
		yield return sceneLoader.LoadScene(Scene);
	}
}
