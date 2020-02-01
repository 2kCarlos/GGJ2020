using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

using static Unity.Mathematics.math;

namespace GGJ2020 {
	/// <summary>
	/// Controls the movement of a given Rigidbody, from the perpsective of the currently-attached Transform.
	/// </summary>
	public class ThirdPersonMovement : MonoBehaviour {
#pragma warning disable 0649
		[Header("Dependencies")]
		[SerializeField] private PlayerInput playerInput;
		[SerializeField] private new Rigidbody rigidbody;
		[SerializeField] private new Collider collider;
		[Space(20)]
		[SerializeField] private ThirdPersonMovementSettings settings;
#pragma warning restore 0649

		private float3 startPosition;

		private float2 inputMove;
		private float inputMoveSqrMag;
		private float3 desiredVelocity;
		private bool isMoving;

		#region Unity Messages
		private void Awake() {
			startPosition = rigidbody.position;
		}

		private void FixedUpdate() {
			float3 velocity = rigidbody.velocity;
			desiredVelocity = new float3(inputMove.x, 0, inputMove.y);
			if (isMoving) {
				//Dividing by the length here (aka dividing by the sqrt of the squared magnitude)
				//normalizes the vector without needing additional calculations
				desiredVelocity = settings.MoveSpeed * (desiredVelocity / sqrt(inputMoveSqrMag));
				desiredVelocity = Quaternion.Euler(0, transform.eulerAngles.y, 0) * desiredVelocity;

				rigidbody.rotation = Quaternion.LookRotation(desiredVelocity, Vector3.up);
			}

			rigidbody.AddForce(desiredVelocity - velocity, ForceMode.VelocityChange);
		}
		#endregion

		#region Public Inspector Methods
		public void InspectorResetPosition() {
			rigidbody.position = startPosition;
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