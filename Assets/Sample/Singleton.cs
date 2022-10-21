namespace Sample {
	public class Singleton {
		private static Singleton _instance;
		private static readonly object Padlock = new();
		private Singleton() { }

		public static Singleton Instance {
			get {
				lock (Padlock) {
					return _instance ??= new Singleton();
				}
			}
		}
	}
}
