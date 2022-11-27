using System.Collections.Generic;
using System.Linq;
using Scenes.GameScene;
using Src.Bullet;
using UnityEngine;
using UnityEngine.UI;

namespace Src.Tower {
	public class Tower : MonoBehaviour {
		private const float Timeout = 0.5f;
		private readonly List<GameObject> _enemies;
		private Button _button;
		private Button _buttonSell;
		private Button _buttonUpgrade;
		private Transform _gunTransform;
		private Transform _head;
		private Transform _muzzleTransform;
		private float _range;
		private Renderer _renderer;
		private float _timeout;
		private GameObject canvas;
		private int counter;
		private Transform turret;

		private Tower() {
			this._enemies = new List<GameObject>();
		}

		private void Awake() {
			this.GetComponent<SphereCollider>().radius = this._range;
			this._renderer = this.GetComponentInChildren<Renderer>();
			this.canvas = GameObject.Find("TowerCanvas");
			this._buttonUpgrade = this.transform.Find("TowerCanvas").Find("Buttons").Find("Upgrade").GetComponent<Button>();
			this._buttonSell = this.transform.Find("TowerCanvas").Find("Buttons").Find("Sell").GetComponent<Button>();
			this._button = this.transform.Find("TowerCanvas").Find("Buttons").Find("Hide").GetComponent<Button>();
			this._head = this.transform.Find("Head");
			this.turret = this.transform.Find("Head").Find("Turret");
			this._gunTransform = this.transform.Find("Head").Find("Gun");
			this._muzzleTransform = this.transform.Find("Head").Find("Muzzle");
			var position = this._gunTransform.position;
			this._muzzleTransform.position = new Vector3(position.x, position.y, position.z - this._gunTransform.localScale.z * 3);
		}

		private void Start() {
			this._button.onClick.AddListener(() => this.canvas.SetActive(false));
			this._buttonSell.onClick.AddListener(() => TowerManager.Instance.DeleteTower(this.gameObject));
			this._buttonUpgrade.onClick.AddListener(() => this.Upgrade(3));
		}

		private void OnDrawGizmos() {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, this._range);
		}

		private void OnMouseDown() {
			if (Input.GetMouseButtonDown(0)) {
				this.canvas.SetActive(true);
			}
		}

		private void OnTriggerEnter(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Add(other.gameObject);
			other.gameObject.GetComponent<Enemy.Enemy>().enemies = this._enemies;
			CanvasUI.Instance.TowerEnemyCount(this._enemies.Count);
		}

		private void OnTriggerExit(Collider other) {
			if (!other.CompareTag("Enemy")) {
				return;
			}

			this._enemies.Remove(other.gameObject);
			CanvasUI.Instance.TowerEnemyCount(this._enemies.Count);
		}

		private void OnTriggerStay(Collider other) {
			var dir = this.turret.position - this._enemies.First().transform.position;
			var lookRotation = Quaternion.LookRotation(dir);
			var rotation = lookRotation.eulerAngles;
			this._head.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			if (other.CompareTag("Enemy")) {
				BulletManager.Instance.Shoot(this._muzzleTransform, this._enemies.First().transform);
			}

			this._timeout = Timeout;
		}

		private void Upgrade(int counter2) {
			if (counter2 <= this.counter) {
				return;
			}

			this.counter++;
			this.SetRange(1);
			this._renderer.material.color = new Color(0, 255, 0);
		}

		public void SetRange(int range) {
			this._range += range;
			this.GetComponent<SphereCollider>().radius = this._range;
		}
	}
}
