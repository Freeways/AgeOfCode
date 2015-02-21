using UnityEngine;
using System.Collections;

public class DoorCollider : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;

	public void OnTriggerEnter(Collider myColl){
		
		if (myColl.gameObject.tag == "door") {
			//	print ("test");
			cam1.enabled = true;
			cam2.enabled = false;
		}
	}

}
