using Common;
using TMPro;
using UnityEngine;

namespace Scenes.GameScene {
	public sealed class CanvasUI : MonoComponent<CanvasUI> {
		[SerializeField] private TextMeshProUGUI level;
		[SerializeField] private TextMeshProUGUI towerCounter;
		[SerializeField] private TextMeshProUGUI enemyCounter;
		[SerializeField] private TextMeshProUGUI bulletCounter;
		[SerializeField] private TextMeshProUGUI dummy;
		[SerializeField] private TextMeshProUGUI towerEnemyCounter;

		public void Level(int param) {
			this.level.text = $"Level: {param}";
		}

		public void TowerCount(int count, int max) {
			this.towerCounter.text = $"Towers: {count} / {max}";
		}

		public void EnemyCounter(int count) {
			this.enemyCounter.text = $"Enemies: {count}";
		}

		public void BulletCounter(int count) {
			this.bulletCounter.text = $"Bullets: {count}";
		}

		public void Dummy(string text) {
			this.dummy.text = text;
		}

		public void TowerEnemyCount(int count) {
			this.towerEnemyCounter.text = $"TowerEnemies: {count}";
		}
	}
}
