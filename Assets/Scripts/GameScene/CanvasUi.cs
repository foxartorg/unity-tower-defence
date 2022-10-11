using TMPro;
using UnityEngine;

namespace GameScene {
	public class CanvasUi : MonoBehaviour {
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
