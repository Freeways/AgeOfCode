using UnityEngine;
using System.Collections;

public class winner : MonoBehaviour {
	
	public void OnTriggerEnter(Collider myColl){
		if (myColl.gameObject.tag == "Player") {
			//Afficher msg
			//wait 2 sec
			Application.LoadLevel(4);
		}
	}
	
}