using UnityEngine;
using System.Collections;

public class RotationAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate(Vector3.up*Time.deltaTime,Space.World);
		transform.Rotate(Vector3.up*1,Space.Self);
	}
}
