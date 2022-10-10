using System.Collections;
using Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {
	private const int LevelIndex = 2;
	[SerializeField] private Button level1Button;
	[SerializeField] private Button level2Button;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI towerCounterText;
	private Manager _enemyManager;
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
		// _enemyManager = GameObject.Find("EnemyManager").GetComponent<Manager>();
		Level = 1;
		levelText.text = $"Level: {Level}";
		towerCounterText.text = "Towers: 0";
	}

	private IEnumerator Start() {
		level1Button.onClick.AddListener(() => StartCoroutine(SwitchToLevel(1)));
		level2Button.onClick.AddListener(() => StartCoroutine(SwitchToLevel(2)));
		var asyncLoad = SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);
		while (!asyncLoad.isDone) {
			yield return null;
		}
	}

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

	private IEnumerator SwitchToLevel(int level) {
		SceneManager.UnloadSceneAsync(Scene);
		Level = level;
		levelText.text = $"Level: {Level}";
		var asyncLoad = SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);
		while (!asyncLoad.isDone) {
			yield return null;
		}
	}

	public void TowerCountText(int count) {
		towerCounterText.text = $"Towers: {count}";
	}
}
