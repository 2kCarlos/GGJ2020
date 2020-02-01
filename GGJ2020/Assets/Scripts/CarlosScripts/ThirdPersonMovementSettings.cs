using System;
using UnityEngine;

namespace GGJ2020 {
	[CreateAssetMenu]
	public class ThirdPersonMovementSettings : ScriptableObject {
#pragma warning disable 0649
		[SerializeField] private PhysicMaterial movingPhysicMaterial;
		[SerializeField] private PhysicMaterial nonMovingPhysicMaterial;
		[SerializeField] private float moveSpeed = 4;
#pragma warning restore 0649

		public float MoveSpeed {
			get { return moveSpeed; }
		}

		public PhysicMaterial MovingPhysicMaterial {
			get { return movingPhysicMaterial; }
		}

		public PhysicMaterial NonMovingPhysicMaterial {
			get { return nonMovingPhysicMaterial; }
		}
	}
}