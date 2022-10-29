using Common;
using Src;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.MainScene {
	public sealed class EventSystem : MonoBehaviour {
		[SerializeField] private Button startButton;

		private void Awake() {
			GameScene.EventSystem.Autoload = false;
		}

		private void Start() {
			this.startButton.onClick.AddListener(this.StartGame);
		}

		private void StartGame() {
			this.StartCoroutine(SceneHelper.Load(App.GameSceneIndex));
			this.StartCoroutine(SceneHelper.Load(App.LevelSceneIndex, true));
		}
	}
}
