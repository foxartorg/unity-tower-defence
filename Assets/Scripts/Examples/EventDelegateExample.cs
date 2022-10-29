using System;

namespace Examples {
	internal class EventDelegateExample {
		protected event EventHandler OnEvent;
		protected event DelegateHandler OnDelegate;

		protected void EventTest() {
			this.OnEvent?.Invoke(this, EventArgs.Empty);
		}

		protected void DelegateTest() {
			this.OnDelegate?.Invoke(this);
		}

		protected delegate void DelegateHandler(object source);
	}

	internal class EventDelegateExampleTest : EventDelegateExample {
		public void Main() {
			this.OnEvent += MyEvent;
			this.OnEvent += (o, e) => { };
			this.OnDelegate += MyDelegate;
			this.OnDelegate += e => { };
			this.DelegateTest();
			this.EventTest();
		}

		private static void MyEvent(object sender, EventArgs e) {
			Console.WriteLine("MyEvent");
		}

		private static void MyDelegate(object sender) {
			Console.WriteLine("MyDelegate");
		}
	}
}
