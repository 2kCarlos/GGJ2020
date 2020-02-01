using System;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ2020 {
	public abstract class RuntimeSet<T> : RuntimeSetBase {
		[SerializeField] private List<T> list = new List<T>();

		//Would prefer to use Unity 2020.1+ generic serialization with UnityEvent<T> in the inspector, but this will do I suppose!
		public event Action<T> onAdd;
		public event Action<T> onRemove;

		public void Add(T obj) {
			list.Add(obj);
			if (onAdd != null)
				onAdd(obj);
		}

		public bool Remove(T obj) {
			bool result = list.Remove(obj);
			if (onRemove != null)
				onRemove(obj);
			return result;
		}
	}
}