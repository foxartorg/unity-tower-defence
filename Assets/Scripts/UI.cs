using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	[SerializeField] private Button level1Button;
	[SerializeField] private Button level2Button;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI towerCounterText;
	private App _app;

	private void Awake() {
		_app = GameObject.Find("App").GetComponent<App>();
	}

	private void Start() {
		level1Button.onClick.AddListener(() => StartCoroutine(_app.SwitchToLevel(1)));
		level2Button.onClick.AddListener(() => StartCoroutine(_app.SwitchToLevel(2)));
	}

	public void LevelText(int level) {
		levelText.text = $"Level: {level}";
	}

	public void TowerCountText(int count) {
		towerCounterText.text = $"Towers: {count}";
	}
}
