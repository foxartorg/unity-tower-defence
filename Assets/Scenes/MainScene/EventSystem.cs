using Common;
using Src;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.MainScene {
	public sealed class EventSystem : MonoBehaviour {
		[SerializeField] private Button startButton;

		private void Start() {
			this.startButton.onClick.AddListener(this.StartGame);
		}

		private void StartGame() {
			GameScene.EventSystem.EnableAutoload();
			this.StartCoroutine(SceneHelper.Load(App.GameSceneIndex));
		}
	}
}
