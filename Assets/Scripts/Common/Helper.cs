using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using SystemRandom = System.Random;

namespace Common {
	public static class Helper {
		private static readonly SystemRandom Random = new();

		public static void ThrowError(string error, [CallerFilePath] string path = "") {
			if (!Application.isEditor) {
				Application.Quit();
			}

			Debug.Break();
			Debug.Log($"Error in {path}");
			throw new Exception(error);
		}

		public static string RandomString(int length) {
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[Random.Next(s.Length)]).ToArray());
		}

		public static T FindComponent<T>(string name, [CallerFilePath] string path = "") {
			// var main = gameObject.GetComponent(typeof(Main)) as Main;
			// var main = GameObject.Find(name).GetComponent<Main>();
			try {
				var component = GameObject.Find(name).GetComponent<T>() as Component;
				if (component) {
					return (T)(object)component;
				}
			} catch {
				ThrowError($"Component not found {name} in {path}");
			}

			return default;
		}

		public static Vector3 PositionParentUp(Transform parent, Transform transform = null) {
			var position = parent.position;
			var scaleY = transform ? transform.localScale.y / 2 : 0f;
			var posY = position.y + parent.localScale.y / 2 + scaleY;
			return new Vector3(position.x, posY, position.z);
		}

		public static Vector3 PositionParentDown(Transform parent, Transform transform = null) {
			var position = parent.position;
			var scaleY = transform ? transform.localScale.y / 2 : 0f;
			var posY = position.y - parent.localScale.y / 2 - scaleY;
			return new Vector3(position.x, posY, position.z);
		}

		public static Vector3 PositionParentRight(Transform parent, Transform transform = null) {
			var position = parent.position;
			var scaleX = transform ? transform.localScale.x / 2 : 0f;
			var posX = position.x + parent.localScale.x / 2 + scaleX;
			return new Vector3(posX, position.y, position.z);
		}
	}
}
