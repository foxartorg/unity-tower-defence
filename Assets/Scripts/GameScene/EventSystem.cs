using UnityEngine;
using UnityEngine.UI;

namespace GameScene {
	public class EventSystem : MonoBehaviour {
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;
		private Main _main;

		private void Awake() {
			_main = Helper.FindComponent<Main>("Main");
		}

		private void Start() {
			level1Button.onClick.AddListener(() => StartCoroutine(_main.SwitchToLevel(1)));
			level2Button.onClick.AddListener(() => StartCoroutine(_main.SwitchToLevel(2)));
		}
	}
}
