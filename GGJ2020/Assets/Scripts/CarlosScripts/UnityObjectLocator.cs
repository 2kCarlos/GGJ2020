using System;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

namespace GGJ2020 {
	[CreateAssetMenu]
	public class UnityObjectLocator : ScriptableServiceLocator, IServiceLocator {
		[SerializeField] private List<Object> objects = new List<Object>();

		public override T Resolve<T>() {
			Type type = typeof(T);
			int index = objects.FindIndex((Object current) => type.IsAssignableFrom(current.GetType()));
			return (index < 0) ? null : objects[index] as T;
		}

		public override void Register<T>(T service) {
			if (service == null)
				throw new ArgumentNullException("service");
			Type type = typeof(T);
			int index = objects.FindIndex((Object current) => type.IsAssignableFrom(current.GetType()));
			if (index >= 0)
				objects[index] = service as Object;
			else
				objects.Add(service as Object);
		}
	}
}