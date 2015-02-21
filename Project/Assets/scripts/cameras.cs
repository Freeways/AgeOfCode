using UnityEngine;
using System.Collections;

public class cameras : MonoBehaviour {
	//Camera cam1,cam2;
	//static int i;
	public Camera cam1;
	public Camera cam2;
	void Start(){
		//i = 0;
		cam1.enabled = false;
		cam2.enabled = true;
	}
	/*
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.C)) {
			if(i%2==0){
				//enable cam 2
				//disable cam 1
				Camera[] tabCam = Camera.GetAllCameras;
				tabCam[0].b

				i++;
			}else{
				//enable cam 1
				//enable cam 2
				i++;
			}
		}
	}
	*/
	void OnGUI () {
		if (GUI.Button (new Rect (500, 50, 120, 30), "Switch view")) {
			
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
		}
	}
}