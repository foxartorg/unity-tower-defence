using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene {
	public class CanvasUI : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI levelText;
		[SerializeField] private TextMeshProUGUI towerCounterText;
		[SerializeField] private TextMeshProUGUI enemyCounterText;

		public void LevelText(int level) {
			this.levelText.text = $"Level: {level}";
		}

		public void TowerCountText(int count, int maxCounterTower) {
			this.towerCounterText.text = $"Towers: {count} / {maxCounterTower}";
		}

		public void EnemyCounterText(int count) {
			this.enemyCounterText.text = $"Enemy: {count}";
		}

		public static void EnemyHealthSlider(int health, Slider slider) {
			slider.value = health;
		}
	}
}
