using System;
using UnityEngine;

namespace GGJ2020 {
	[CreateAssetMenu]
	public class ThirdPersonMovementSettings : ScriptableObject {
		[SerializeField] private PhysicMaterial movingPhysicMaterial;
		[SerializeField] private PhysicMaterial nonMovingPhysicMaterial;
		[SerializeField] private float moveSpeed = 10;

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