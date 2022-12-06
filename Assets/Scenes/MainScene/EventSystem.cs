using Common;
using Src;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.MainScene {
	public sealed class EventSystem : MonoBehaviour {
		[SerializeField] private Button startButton;

		private void Start() {
			this.startButton.onClick.AddListener(this.LoadGameScene);
		}

		private void LoadGameScene() {
			this.StartCoroutine(SceneHelper.Load(App.GameSceneIndex));
		}
	}
}
