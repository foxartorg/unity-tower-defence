using TMPro;
using UnityEngine;

namespace UI {
	public class TowerCounterText : MonoBehaviour {
		private static TextMeshProUGUI _text;

		private void Start() {
			_text = GetComponent<TextMeshProUGUI>();
		}

		public static void UpdateText(int count) {
			_text.text = $"towers: {count}";
		}
	}
}
