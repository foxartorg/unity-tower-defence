using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Src.Enemy {
	public sealed class Enemy : MonoBehaviour {
		public List<GameObject> towerList;
		private int _health = 100;
		private NavMeshAgent _navMeshAgent;
		private Slider _slider;

		private void Awake() {
			this._navMeshAgent = this.GetComponent<NavMeshAgent>();
			this._navMeshAgent.speed = (float)(3.5 / 2);
			this._navMeshAgent.acceleration = 4;
			this._slider = this.GetComponentInChildren<Slider>();
			this._slider.maxValue = this._health;
			this._slider.value = this._health;
		}

		public void Create(Vector3 position) {
			this._navMeshAgent.SetDestination(position);
		}
		
		public void Damage(int damage) {
			this._health -= damage;
			this._slider.value = this._health;
			if (this._health > 0) {
				return;
			}

			EnemyManager.Instance.DestroyEnemy(this.gameObject,this.towerList);
		}

		private void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag("Tower")) {
				this.towerList.Add(other.gameObject);
			}
			if (other.gameObject.CompareTag("SpawnEnd")) {
				EnemyManager.Instance.DestroyEnemy(this.gameObject,this.towerList);
			}
		}

		private void OnTriggerExit(Collider other) {
			if (other.gameObject.CompareTag("Tower")) {
				this.towerList.Remove(other.gameObject);
			}
		}

	}
}
