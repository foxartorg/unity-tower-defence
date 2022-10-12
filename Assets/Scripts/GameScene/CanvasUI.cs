using TMPro;
using UnityEngine;

namespace GameScene {
	public class CanvasUI : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI levelText;
		[SerializeField] private TextMeshProUGUI towerCounterText;
		[SerializeField] private TextMeshProUGUI enemyCounterText;

		public void LevelText(int level) {
			this.levelText.text = $"Level: {level}";
		}

		public void TowerCountText(int count) {
			this.towerCounterText.text = $"Towers: {count}";
		}

		public void EnemyCounterText(int count) {
			this.enemyCounterText.text = $"Enemy: {count}";
		}
	}
}
