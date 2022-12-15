using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameScene {
	public class UICanvas : MonoInstance<UICanvas> {
		[SerializeField] private TextMeshProUGUI levelText;
		[SerializeField] private TextMeshProUGUI bulletCounterText;
		[SerializeField] private TextMeshProUGUI enemyCounterText;
		[SerializeField] private TextMeshProUGUI towerCounterText;
		[SerializeField] private TextMeshProUGUI dummyText;
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;
		[SerializeField] private Button menuButton;

		private void Start() {
			this.menuButton.onClick.AddListener(EventSystem.Instance.LoadMainScene);
			this.level1Button.onClick.AddListener(() => EventSystem.Instance.LoadLevelScene(1));
			this.level2Button.onClick.AddListener(() => EventSystem.Instance.LoadLevelScene(2));
		}

		public void Level(int index) {
			this.levelText.text = $"Level: {index}";
		}

		public void BulletCounter(int count) {
			this.bulletCounterText.text = $"Bullets: {count}";
		}

		public void EnemyCounter(int count) {
			this.enemyCounterText.text = $"Enemies: {count}";
		}

		public void TowerCount(int count, int max) {
			this.towerCounterText.text = $"Towers: {count} / {max}";
		}

		public void Dummy(string text) {
			this.dummyText.text = text;
		}
	}
}
