using UnityEngine;

namespace Common {
	public abstract class Subscriber : MonoBehaviour {
		public delegate void DelegateCreate();

		public delegate void DelegateDestroy(GameObject context);

		public event DelegateCreate OnCreate;
		public event DelegateDestroy OnDestroy;

		protected void CreateHandler() {
			this.OnCreate?.Invoke();
		}

		protected void DestroyHandler(GameObject context) {
			this.OnDestroy?.Invoke(context);
		}
	}
}
