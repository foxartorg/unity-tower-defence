using TMPro;
using UnityEngine;

namespace GameScene {
	public sealed class CanvasUI : SceneSingleton<CanvasUI> {
		[SerializeField] private TextMeshProUGUI level;
		[SerializeField] private TextMeshProUGUI towerCounter;
		[SerializeField] private TextMeshProUGUI enemyCounter;
		[SerializeField] private TextMeshProUGUI dummy;

		public void LevelText(int param) {
			this.level.text = $"Level: {param}";
		}

		public void TowerCountText(int count, int max) {
			this.towerCounter.text = $"Towers: {count} / {max}";
		}

		public void EnemyCounterText(int count) {
			this.enemyCounter.text = $"Enemy: {count}";
		}

		public void DummyText(string text) {
			this.dummy.text = text;
		}
	}
}
