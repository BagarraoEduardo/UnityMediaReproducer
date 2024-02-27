using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MediaListener.Core
{

	public class InputManager : MonoBehaviour
	{
		public static InputManager Instance { get; private set; }
	
		public Vector2 Movement { get; private set; } = default;
	
		void Awake()
		{
			if (Instance != null && Instance != this) 
			{ 
				Destroy(this); 
			} 
			else 
			{ 
				Instance = this; 
			} 
		}
	
		void Update()
		{
			try
			{
				Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));		
			}
				catch(Exception exception)
				{
					Debug.LogException(exception, this);
					Movement = Vector2.zero;
				}
		}
	}
}