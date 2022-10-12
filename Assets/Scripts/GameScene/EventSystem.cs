using UnityEngine;
using UnityEngine.UI;

namespace GameScene {
	public class EventSystem : MonoBehaviour {
		[SerializeField] private Button menuButton;
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;
		private Main _main;

		private void Awake() {
			_main = Helper.FindComponent<Main>("Main");
		}

		private void Start() {
			menuButton.onClick.AddListener(() => StartCoroutine(SceneLoader.LoadScene(0, false)));
			level1Button.onClick.AddListener(() => StartCoroutine(_main.SwitchToLevel(1)));
			level2Button.onClick.AddListener(() => StartCoroutine(_main.SwitchToLevel(2)));
		}
	}
}
