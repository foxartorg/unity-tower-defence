using System;
using UnityEngine;

namespace Common {
	public static class Helper {
		public static void ThrowError(string error) {
			if (!Application.isEditor) {
				Application.Quit();
			}

			Debug.Break();
			throw new Exception(error);
		}

		public static T FindComponent<T>(string name) {
			// var main = gameObject.GetComponent(typeof(Main)) as Main;
			// var main = GameObject.Find(name).GetComponent<Main>();
			var component = GameObject.Find(name).GetComponent<T>() as Component;
			if (component) {
				return (T)(object)component;
			}

			ThrowError($"Component not found: {name}");
			return default;
		}

		public static Vector3 PositionUpFromParent(Transform gameObjectTransform, Transform parentTransform) {
			var position = parentTransform.position;
			var y = position.y + parentTransform.localScale.y / 2 + gameObjectTransform.localScale.y;
			return new Vector3(position.x, y, position.z);
		}
	}
}
