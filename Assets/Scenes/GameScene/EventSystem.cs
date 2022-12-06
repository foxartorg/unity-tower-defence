using Common;
using Src;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameScene {
	public sealed class EventSystem : MonoBehaviour {
		private static bool _autoload;
		[SerializeField] private Button menuButton;
		[SerializeField] private Button level1Button;
		[SerializeField] private Button level2Button;
		private int _prev;

		private EventSystem() {
			_autoload = true;
		}

		private void Awake() {
			Application.targetFrameRate = 60;
		}

		private void Start() {
			if (_autoload) {
				_autoload = false;
				App.Level = 1;
				this._prev = App.LevelScene;
				this.LoadLevel(App.Level);
			}

			this.menuButton.onClick.AddListener(() => this.StartCoroutine(SceneHelper.Load(App.MainSceneIndex)));
			this.level1Button.onClick.AddListener(() => this.LoadLevel(1));
			this.level2Button.onClick.AddListener(() => this.LoadLevel(2));
		}

		public static void EnableAutoload() {
			_autoload = true;
		}

		private void LoadLevel(int level) {
			if (SceneHelper.IsLoaded(this._prev)) {
				this.StartCoroutine(SceneHelper.Unload(this._prev));
			}

			App.Level = level;
			this.StartCoroutine(SceneHelper.Load(App.LevelScene, true));
			this._prev = App.LevelScene;
			CanvasUI.Instance.Level(App.Level);
			CanvasUI.Instance.TowerCount(0, 0);
			CanvasUI.Instance.EnemyCounter(0);
			CanvasUI.Instance.BulletCounter(0);
			CanvasUI.Instance.TowerEnemyCount(0);
		}
	}
}
