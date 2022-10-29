using System.Collections;
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
			this.startButton.onClick.AddListener(() => this.StartCoroutine(this.StartGame()));
		}

		private IEnumerator StartGame() {
			this.StartCoroutine(SceneHelper.Load(App.GameSceneIndex));
			// var scene = SceneHelper.Get(App.GameSceneIndex);
			this.StartCoroutine(SceneHelper.Load(App.LevelSceneIndex, true));
			var scene = SceneHelper.Get(App.LevelSceneIndex);
			while (!scene.isLoaded) {
				yield return null;
			}
		}
	}
}
