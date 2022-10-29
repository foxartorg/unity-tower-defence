using UnityEngine;
using UnityEngine.UI;

namespace GameScene {
	public sealed class EventSystem : MonoBehaviour {
		[SerializeField] private Button menuButton;
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;

		private void Start() {
			this.menuButton.onClick.AddListener(() => this.StartCoroutine(Main.SwitchToMenu()));
			this.level1Button.onClick.AddListener(() => this.StartCoroutine(Main.SwitchToLevel(1)));
			this.level2Button.onClick.AddListener(() => this.StartCoroutine(Main.SwitchToLevel(2)));
		}
	}
}
