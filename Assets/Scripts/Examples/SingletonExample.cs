namespace Examples {
	internal sealed class SingletonExample {
		private static SingletonExample _instance;
		private static readonly object Padlock = new();
		private SingletonExample() { }

		public static SingletonExample Instance {
			get {
				lock (Padlock) {
					return _instance ??= new SingletonExample();
				}
			}
		}
	}
}
