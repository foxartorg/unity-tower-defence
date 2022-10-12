using TMPro;
using UnityEngine;

namespace GameScene {
	public class CanvasUI : MonoBehaviour {
		[SerializeField] private TextMeshProUGUI levelText;
		[SerializeField] private TextMeshProUGUI towerCounterText;

		public void LevelText(int level) {
			levelText.text = $"Level: {level}";
		}

		public void TowerCountText(int count) {
			towerCounterText.text = $"Towers: {count}";
		}
	}
}
