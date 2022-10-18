using UnityEngine;

namespace Common {
	public abstract class Subscriber : MonoBehaviour {
		public delegate void DelegateCreate();

		public delegate void DelegateDestroy(GameObject context);

		public event DelegateCreate OnCreate;
		public event DelegateDestroy OnDestroy;

		protected void execCreate() {
			this.OnCreate?.Invoke();
		}

		protected void execDestroy(GameObject context) {
			this.OnDestroy?.Invoke(context);
		}
	}
}
