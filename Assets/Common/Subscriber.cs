using UnityEngine;

namespace Common {
	public abstract class Subscriber : MonoBehaviour {
		public delegate void DelegateCreate();

		public delegate void DelegateDestroy(GameObject context);

		public event DelegateCreate HookCreate;
		public event DelegateDestroy HookDestroy;

		protected void ExecCreate() {
			this.HookCreate?.Invoke();
		}

		protected void ExecDestroy(GameObject context) {
			this.HookDestroy?.Invoke(context);
		}
	}
}
