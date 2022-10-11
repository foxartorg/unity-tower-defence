using System;
using UnityEngine;

public static class Helper {
	public static T FindComponent<T>(string name) {
		// var main = gameObject.GetComponent(typeof(Main)) as Main;
		// var main = GameObject.Find(name).GetComponent<Main>();
		var main = GameObject.Find(name).GetComponent<T>() as Component;
		if (!main) {
			throw new Exception($"{name} not found");
		}

		return (T)(object)main;
	}
}
