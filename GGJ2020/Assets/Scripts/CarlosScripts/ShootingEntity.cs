using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GGJ2020 {
	public class ShootingEntity : MonoBehaviour {
		[SerializeField] private new Camera camera;
		[SerializeField] private GameObject projectilePrefab;

		#region InputSystem Messages
		private void OnFire() {
			Vector3 mousePos = Mouse.current.position.ReadValue();
			Ray worldRay = camera.ScreenPointToRay(mousePos);
			Plane p = new Plane(Vector3.up, 0);
			if (p.Raycast(worldRay, out float distance)) {
				Vector3 position = transform.position;
				Vector3 delta = Vector3.Normalize((worldRay.origin + distance * worldRay.direction) - position);

				Quaternion newRot = Quaternion.LookRotation(delta, Vector3.up);
				transform.rotation = newRot;
				GameObject.Instantiate(projectilePrefab, position + delta * 0.5f, newRot);
			}
		}
		#endregion
	}
}