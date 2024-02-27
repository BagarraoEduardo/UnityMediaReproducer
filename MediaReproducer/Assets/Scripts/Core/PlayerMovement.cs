using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MediaListener.Core
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField]
		private float _movementSpeed = 0f;
	
		[SerializeField]
		private Rigidbody _rigidbody;

		// Update is called once per frame
		void FixedUpdate()
		{
			var torque = new Vector3(InputManager.Instance.Movement.x * _movementSpeed, 0, InputManager.Instance.Movement.y * _movementSpeed);
		
			_rigidbody.AddTorque(torque);
		}
	}
}
