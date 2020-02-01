using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

using static Unity.Mathematics.math;

namespace GGJ2020 {
	public class ThirdPersonMovement : MonoBehaviour {
		[SerializeField] private PlayerInput playerInput;
		[SerializeField] private new Rigidbody rigidbody;
		[SerializeField] private new Collider collider;
		[Space(20)]
		[SerializeField] private ThirdPersonMovementSettings settings;

		private float2 inputMove;
		private float inputMoveSqrMag;
		private float3 desiredVelocity;
		private bool isMoving;

		#region Unity Messages
		private void FixedUpdate() {
			float3 velocity = rigidbody.velocity;
			desiredVelocity = new float3(inputMove.x, 0, inputMove.y);
			if (isMoving) {
				//Dividing by the length here (aka dividing by the sqrt of the squared magnitude)
				//normalizes the vector without needing additional calculations
				desiredVelocity = settings.MoveSpeed * (desiredVelocity / sqrt(inputMoveSqrMag));

			}

			rigidbody.AddForce(desiredVelocity - velocity, ForceMode.VelocityChange);
		}
		#endregion


		#region InputSystem Messages
		private void OnMove(InputValue value) {
			inputMove = value.Get<Vector2>();
			inputMoveSqrMag = lengthsq(inputMove);
			isMoving = inputMoveSqrMag >= 0.01f;
			collider.material = (isMoving) ? settings.MovingPhysicMaterial : settings.NonMovingPhysicMaterial;
		}
		#endregion
	}
}