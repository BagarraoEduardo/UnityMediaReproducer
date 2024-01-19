using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MediaListener.Core
{

	public class DownloadPlay : MonoBehaviour
	{
		void OnTriggerEnter(Collider other)
		{
			Debug.Log("Download - Collision Enter");
		}
	
		void OnTriggerStay(Collider other)
		{
			Debug.Log("Download - Collision Stay");
		}
	
		void OnTriggerExit(Collider other)
		{
			Debug.Log("Download - Collision Exit");
		}
	}
}
