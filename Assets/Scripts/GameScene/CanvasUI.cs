using TMPro;
using UnityEngine;

namespace GameScene {
	public sealed class CanvasUI : SceneSingleton<CanvasUI> {
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
	}
}
