using System.Collections.Generic;
using Common;
using Scenes.GameScene;
using Src.Bullet;
using UnityEngine;
using UnityEngine.UI;

namespace Src.Tower {
	public class Tower : MonoInstance<Tower> {
		private const float ShootTimeout = 0.5f;
		private readonly List<GameObject> _enemyList;
		private Transform _gunTransform;
		private Transform _headTransform;
		private Transform _muzzleTransform;
		private float _range;
		private Renderer _renderer;
		private float _timeout;
		private Transform _turretTransform;
		private GameObject _canvasGameObject;
		private GameObject _textGameObject;
		private Canvas _canvas;
		private Text _text;
		private RectTransform _rectTransform;
		private Tower() {
			this._enemyList = new List<GameObject>();
		}

		public GameObject Platform { get; set; }

		private void Awake() {
			this.GetComponentInChildren<SphereCollider>().radius = this._range = 5f;
			this._renderer = this.GetComponentInChildren<Renderer>();
			this._headTransform = this.transform.Find("Head");
			this._turretTransform = this._headTransform.Find("Turret");
			this._muzzleTransform = this._headTransform.Find("Muzzle");
			var gunTransform = this._headTransform.Find("Gun");
			this._muzzleTransform.position = Helper.PositionParentRight(gunTransform);
			// this._muzzleTransform.position = new Vector3(this._muzzleTransform.position.x, this._muzzleTransform.position.y + 0.1f,
			// this._gunTransform.position.z);
			//Canvas
			this._canvasGameObject = new GameObject();
			this._canvasGameObject.transform.parent = this.transform;
			this._canvasGameObject.name = "Canvas";
			this._canvas = this._canvasGameObject.AddComponent<Canvas>();
			this._canvas.renderMode = RenderMode.WorldSpace;
			//Text
			this._textGameObject = new GameObject();
			this._textGameObject.transform.parent = this._canvasGameObject.transform;
			this._textGameObject.name = "Text";
			this._text = this._textGameObject.AddComponent<Text>();
			this._text.font = Resources.Load<Font>("Fonts/LiberationSans");
			this._text.text = "njj";
			this._text.fontSize = 10;
			// Text position
			this._rectTransform = this._text.GetComponent<RectTransform>();
			this._rectTransform.localPosition = new Vector3(0, 0, 0);
			this._rectTransform.sizeDelta = new Vector2(20, 20);
		}

		private void OnDrawGizmos() {
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(this.transform.position, this._range / 2);
		}

		private void OnMouseDown() {
			if (!Input.GetMouseButtonDown(0)) {
				return;
			}

			TowerMenuCanvas.Instance.Show(this.gameObject);
		}

		private void OnTriggerEnter(Collider component) {
			if (!App.IsEnemyTag(component)) {
				return;
			}

			this._enemyList.Add(component.gameObject);
			// UserInterface.Instance.TowerEnemyCount(this._enemyList.Count);
		}

		private void OnTriggerExit(Collider component) {
			if (!App.IsEnemyTag(component)) {
				return;
			}

			this._enemyList.Remove(component.gameObject);
		}

		private void OnTriggerStay(Collider component) {
			if (!App.IsEnemyTag(component)) {
				return;
			}

			if (this._timeout > 0) {
				this._timeout -= Time.deltaTime;
				return;
			}

			this._timeout = ShootTimeout;
			this.Shoot();
		}

		private Vector3 FindEnemyPosition() {
			return this._enemyList[0] ? this._enemyList[0].transform.position : default;
		}

		private void AimTo(Vector3 position) {
			var forward = this._turretTransform.position - position;
			var rotation = Quaternion.LookRotation(forward).eulerAngles;
			this._headTransform.transform.rotation = Quaternion.Euler(0f, rotation.y + 90, rotation.z);
		}

		private void Shoot() {
			var position = this.FindEnemyPosition();
			if (position == default) {
				return;
			}

			this.AimTo(position);
			var bullet = BulletManager.Instance.CreateBullet(this._muzzleTransform);
			bullet.GetComponent<Bullet.Bullet>().MoveTo(position);
		}

		public void Upgrade() {
			this._range += 1f;
			this._renderer.material.color = Color.green;
		}
	}
}
