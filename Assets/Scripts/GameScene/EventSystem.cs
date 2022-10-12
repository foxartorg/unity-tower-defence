using Common;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene {
	public class EventSystem : MonoBehaviour {
		[SerializeField] private Button menuButton;
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;
		private Main _main;

		private void Awake() {
			this._main = Helper.FindComponent<Main>("Main");
		}

		private void Start() {
			this.menuButton.onClick.AddListener(() => this.StartCoroutine(SceneLoader.LoadScene(0, false)));
			this.level1Button.onClick.AddListener(() => this.StartCoroutine(this._main.SwitchToLevel(1)));
			this.level2Button.onClick.AddListener(() => this.StartCoroutine(this._main.SwitchToLevel(2)));
		}
	}
}
