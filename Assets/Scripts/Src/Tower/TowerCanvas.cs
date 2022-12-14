using UnityEngine;
using UnityEngine.UI;

namespace Src.Tower {
	public class TowerCanvas : MonoBehaviour {
		public GameObject tower;
		private Button _buttonHide;
		private Button _buttonSell;
		private Button _buttonUpgrade;
		private Tower _tower;

		private void Awake() {
			this._tower = this.tower.GetComponent<Tower>();
			var buttons = this.gameObject.transform.Find("Buttons");
			this._buttonUpgrade = buttons.Find("Upgrade").GetComponent<Button>();
			this._buttonSell = buttons.Find("Sell").GetComponent<Button>();
			this._buttonHide = buttons.Find("Hide").GetComponent<Button>();
		}

		private void Start() {
			this._buttonUpgrade.onClick.AddListener(this._tower.Upgrade);
			this._buttonSell.onClick.AddListener(() => TowerManager.Instance.DestroyTower(this.tower));
			this._buttonHide.onClick.AddListener(() => this.gameObject.SetActive(false));
		}
	}
}
