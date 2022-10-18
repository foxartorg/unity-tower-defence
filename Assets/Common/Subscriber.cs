using UnityEngine;

namespace Common {
	public class Subscriber : MonoBehaviour {
		public delegate void Delegate();

		public event Delegate OnCreate;
		public event Delegate OnDestroy;

		protected void CreateHandler() {
			this.OnCreate?.Invoke();
		}

		protected void DestroyHandler() {
			this.OnDestroy?.Invoke();
		}
	}
}
