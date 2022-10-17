using UnityEngine;

namespace App.Enemy {
	public class EnemyBuilder : MonoBehaviour {
		public delegate void DestroyEnemyDelegate();

		public event DestroyEnemyDelegate OnDestroyEnemy;

		protected void DestroyEnemy() {
			this.OnDestroyEnemy?.Invoke();
		}
	}
}
