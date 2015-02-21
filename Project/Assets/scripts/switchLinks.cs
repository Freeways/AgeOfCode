using UnityEngine;
using System.Collections;

public class switchLinks : MonoBehaviour {
	// Index of any scene to change. To view your scene index, see File/Build Settings
	// drag your scene.
	public void exitscene (){
		Application.Quit ();
	}

	public void ChangeToScene(int sceneIndex){
		Application.LoadLevel(sceneIndex);
	}
}
