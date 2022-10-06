using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
	public class UserInterface : MonoBehaviour {
		private const int LevelIndex = 2;
		private int _level = LevelIndex;

		// Start is called before the first frame update
		private void Start() {
			SceneManager.LoadSceneAsync(_level, LoadSceneMode.Additive);
		}

		private void SwitchToLevel(int level) {
			SceneManager.UnloadSceneAsync(_level);
			_level = level;
			SceneManager.LoadSceneAsync(_level, LoadSceneMode.Additive);
		}

		public void Level1() {
			SwitchToLevel(LevelIndex);
		}

		public void Level2() {
			SwitchToLevel(LevelIndex + 1);
		}
	}
}