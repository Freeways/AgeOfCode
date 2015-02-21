using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class PlayClosingDoos : MonoBehaviour {
	public AudioClip doorClosing;
	// Use this for initialization
	void Start () {
		audio.PlayOneShot(doorClosing/*, 0.7F*/);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
