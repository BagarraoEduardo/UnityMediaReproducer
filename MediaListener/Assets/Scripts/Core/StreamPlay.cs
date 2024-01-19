using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MediaListener.Core
{
	public class StreamPlay : MonoBehaviour
	{
		void OnTriggerEnter(Collider other)
		{
			Debug.Log("Stream - Collision Enter");
		}
	
		void OnTriggerStay(Collider other)
		{
			Debug.Log("Stream - Collision Stay");
		}
	
		void OnTriggerExit(Collider other)
		{
			Debug.Log("Stream - Collision Exit");
		}
	}
}