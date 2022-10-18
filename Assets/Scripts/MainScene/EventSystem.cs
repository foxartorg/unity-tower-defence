using UnityEngine;
using UnityEngine.UI;

namespace MainScene {
	public sealed class EventSystem : MonoBehaviour {
		[SerializeField] private Button startButton;

		private void Start() {
			this.startButton.onClick.AddListener(() => this.StartCoroutine(SceneLoader.LoadScene(1, false)));
		}
	}
}
