using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class GoToLevel2 : MonoBehaviour {

	//public AudioClip doorClosing;

	public void OnTriggerEnter(Collider myColl){
			
		if (myColl.gameObject.tag == "Player") {
			//Afficher msg
			//wait 2 sec
			//audio.PlayOneShot(doorClosing/*, 0.7F*/);
			Application.LoadLevel(2);

		}
	}

}