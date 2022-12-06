using Src;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameScene {
	public sealed class EventSystem : MonoBehaviour {
		[SerializeField] private Button menuButton;
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;

		private void Awake() {
			if (App.Autoload) {
				Debug.Log("AUTOLOAD");
			}
		}

		private void Start() {
			this.menuButton.onClick.AddListener(() => App.Instance.LoadMainScene());
			this.level1Button.onClick.AddListener(() => App.Instance.LoadLevelScene(1));
			this.level2Button.onClick.AddListener(() => App.Instance.LoadLevelScene(2));
		}
	}
}
