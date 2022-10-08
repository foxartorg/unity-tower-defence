using UnityEngine;
using TMPro;

namespace Tower {
    public class TowerCounter : MonoBehaviour {
        private int _counter;
        private TextMeshProUGUI _test;

        private void Start() {
            _test = GetComponent<TextMeshProUGUI>();
        }

        private void Update() {
            _counter = Wall.Counter;
            _test.text = "Tower Placed:" + _counter;
        }
    }
}
