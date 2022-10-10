using TMPro;
using UnityEngine;

namespace Tower {
	public class TowerCounterText : MonoBehaviour {
		private int _counter;
		private TextMeshProUGUI _text;

		private void Start() {
			_text = GetComponent<TextMeshProUGUI>();
		}

		private void Update() {
			UpdateText();
		}

		private void UpdateText() {
			_counter = Wall.Counter;
			_text.text = "Tower Placed:" + _counter;
		}
	}
}
