using UnityEngine;
using UnityEngine.UI;

namespace MainScene {
	public class EventSystem : MonoBehaviour {
		[SerializeField] private Button startButton;
		private void Awake() { }

		private void Start() {
			startButton.onClick.AddListener(() => StartCoroutine(SceneLoader.LoadScene(1, false)));
		}
	}
}
