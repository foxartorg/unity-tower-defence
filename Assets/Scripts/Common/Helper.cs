using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using SystemRandom = System.Random;

namespace Common {
	public static class Helper {
		private static readonly SystemRandom Random = new();

		public static void ThrowError(string error) {
			if (!Application.isEditor) {
				Application.Quit();
			}

			Debug.Break();
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

		public static Vector3 PositionParentUp(Transform gameObject, Transform parentTransform) {
			var position = parentTransform.position;
			// var y = position.y + transform.localScale.y / 2 + gameObject.localScale.y;
			var y = position.y + parentTransform.localScale.y / 2 + gameObject.localScale.y;
			// Debug.Log($"Y {position.y} {parentTransform.localScale.y / 2} {gameObject.localScale.y}");
			return new Vector3(position.x, y, position.z);
		}

		public static Vector3 PositionParentDown(Transform gameObject, Transform parentTransform) {
			var position = parentTransform.position;
			var y = position.y - parentTransform.localScale.y / 2 - gameObject.localScale.y;
			return new Vector3(position.x, y, position.z);
		}
	}
}
