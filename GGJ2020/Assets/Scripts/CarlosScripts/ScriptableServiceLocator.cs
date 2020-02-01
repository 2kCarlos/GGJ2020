using System;
using UnityEngine;

using Object = UnityEngine.Object;

namespace GGJ2020 {
	public abstract class ScriptableServiceLocator : ScriptableObject, IServiceLocator {
		public abstract T Resolve<T>() where T : class;
		public abstract void Register<T>(T service) where T : class;
	}
}