using Common;
using Src.Tower;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.GameScene {
	public class TowerMenu : MonoInstance<TowerMenu> {
		[SerializeField] private Button upgradeButton;
		[SerializeField] private Button sellButton;
		[SerializeField] private Button hideButton;
		private GameObject Tower { get; set; }

		private void Start() {
			this.gameObject.SetActive(false);
			this.sellButton.onClick.AddListener(this.Sell);
			this.upgradeButton.onClick.AddListener(this.Upgrade);
			this.hideButton.onClick.AddListener(this.Hide);
		}

		public void Show(GameObject tower) {
			this.Tower = tower;
			this.gameObject.SetActive(true);
		}

		private void Sell() {
			TowerManager.Instance.DestroyTower(this.Tower);
			this.Tower = null;
			this.gameObject.SetActive(false);
		}

		private void Upgrade() {
			TowerManager.Instance.UpgradeTower(this.Tower);
			this.Tower = null;
			this.gameObject.SetActive(false);
		}

		private void Hide() {
			this.Tower = null;
			this.gameObject.SetActive(false);
		}
	}
}
