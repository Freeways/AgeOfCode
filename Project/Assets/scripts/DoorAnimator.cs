using UnityEngine;
using System.Collections;

public class DoorAnimator : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;

	void Start(){
		//i = 0;
		cam1.enabled = false;
		cam2.enabled = true;
	}

	public void OnTriggerEnter(Collider myColl){
		if (myColl.gameObject.tag == "door") {
				print ("Door close");
				//cam1.enabled = !cam1.enabled;
				//cam2.enabled = !cam2.enabled;
		}
	}

	/*
	void Start(){
		//i = 0;
		cam1.enabled = false;
		cam2.enabled = true;
	}
	void Update() {
		if (animation.IsPlaying ("DoorOpen")) {
			print ("test");
		}
	}
	*/
}