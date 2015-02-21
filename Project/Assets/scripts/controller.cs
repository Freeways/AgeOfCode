using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;


public class controller : MonoBehaviour {
	float jumpheight = 3.5f;
	float speed = 180;
	bool isFalling = false;

	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.UpArrow) && (!isFalling) /*&& (Player.isGrounded)*/) {
			moveForward ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && (!isFalling) /*&& (Player.isGrounded)*/) {
			moveBackward ();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && (!isFalling) /*&& (Player.isGrounded)*/) {
			moveRight ();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && (!isFalling) /*&& (Player.isGrounded)*/) {
			moveLeft ();
		}
		if (Input.GetKeyDown (KeyCode.Space) && (!isFalling) /*&& (Player.isGrounded)*/) {
			jump();
		}
	}
	
	void moveLeft (){
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
		//if (transform.rotation.y == 1) {
			rigidbody.AddForce (Vector3.forward * speed);
		/*} else {
			rigidbody.AddForce (Vector3.forward * speed);
		}*/
	}
	void moveRight (){
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
		rigidbody.AddForce (Vector3.back * speed);
	}
	void moveForward (){
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		rigidbody.AddForce (Vector3.right * speed);
	}
	void moveBackward (){
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
		rigidbody.AddForce (Vector3.left * speed);
	}
	void jump (){
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
		Vector3 v = rigidbody.velocity;
		v = Vector3.forward * 0.1f;
		v.y = jumpheight;
		rigidbody.velocity = v;
		isFalling = true;
	}

	void OnCollisionStay (){
		isFalling = false;
	}

	/*void isGrounded (){
		if (rigidbody.transform.position.y < 0.246) {
			isFalling = false;
			print ("test 1");
		} else {
			isFalling = true;
			print ("test 2");
		}
	}*/

	 void avancer(string lesit)
	{
		string[] iterations = lesit.Trim().Split(';');
		foreach (string word in iterations)
		{
			string w = word.Trim();
			switch (w)
			{
			case "left":
				moveLeft();
				//print("this is left :" + w);
				continue;
			case "right":
				moveRight();
				//print("this is right :" + w);
				continue;
			case "forward":
				moveForward ();
				//print("this is forward :" + w);
				continue;
			case "backward":
				moveBackward();
				//print("this is backword :" + w);
				continue;
			case "jump":
				if(!isFalling){
					jump();
				}
				//print("this is jump :" + w);
				break;
				
			}
			//Console.WriteLine(w);
		}
	}

	void treat_for(string text){
		Regex rgx = new Regex(@"for[\s]*\(int([\s]+)([\w]+)[\s]*=[\s]*([\d]+)[\s]*;[\s]*([\w]+)[\s]*((<)|(<=)|(>)|(=>))[\s]*[\w]*([\d]+)[\s]*;[\s]*([\w]+)([-|+]{2})\)[\s]*\{[\s]*(((backward|forward|left|right|jump)[\s]*[;]{1}[\s]*)*)}");
		Match m = rgx.Match(text);
		if (m.Success) {
						int deb = int.Parse (m.Groups [3].Value);
						int fin = int.Parse (m.Groups [10].Value);
						string lesit = m.Groups [13].Value;
						string op = m.Groups [5].Value;

						//Console.WriteLine(lesit);
						//Console.WriteLine("#############################################");
			
						switch (op) {
						case "<":
								for (int i = deb; i < fin; i++) {
										avancer (lesit);
								}
								break;
						case "<=":
								for (int i = deb; i <= fin; i++) {
										avancer (lesit);
								}
								break;
						case ">":
								for (int i = deb; i > fin; i++) {
										avancer (lesit);
								}
								break;
						case ">=":
								for (int i = deb; i >= fin; i++) {
										avancer (lesit);
								}
								break;		
						}		
				} else {
						treat (text);
				}
	}
	void treat(string text){
				Regex rgx = new Regex (@"(((backward|forward|left|right|jump)[\s]*;{1}([\s]*))*$)");
				Match m = rgx.Match (text);
		
				if (m.Success) {
			
						string lescmd = m.Groups [1].Value;
						avancer (lescmd); 
				}
		}


	//notice these are pulled out from the method and now attached to the script 
	//string text = "for(int in=0;in <= 8 ; in++) { left; right;}"; 
	//string textar=""; 
	//string textAreaString="left;\n right;\n forward;\n backward;"; 
	string textAreaString=""; 

	GUIStyle largeFont;

	void Start (){
		largeFont = new GUIStyle();
		largeFont.fontSize = 16; 
		largeFont.normal.background = text;
		largeFont.normal.textColor = Color.white;
	}

	public Texture2D text;

	void OnGUI () {
		textAreaString = GUI.TextArea (new Rect (280, 570, 500, 180),textAreaString, largeFont); 

		//text = GUI.TextField (new Rect (250, 93, 250, 25), text,120); 
		//Regex rgx = new Regex(@"for([\s]*)\(int([\s]+)[\w]+[\s]*=[\s]*[\d]+[\s]*;[\s]*[\w]+[\s]*((<)|(<=)|(>)|(=>))[\s]*[\w]*[\d]+[\s]*;[\s]*[\w]+[-|+]{2}\)[\s]*\{[\s]*((backward|forward|left|right|jump)[\s]*[;]{1}[\s]*)*}"); 
		if (GUI.Button (new Rect (850, 600, 120, 30), "validate")) { 
			treat_for(textAreaString);
			textAreaString="";
		}

		if (GUI.Button (new Rect (850, 650, 120, 30), "Restart")) { 
			//print(text); 
			//print(rgx.IsMatch(text)); 

				//Afficher msg
				//wait 2 secs
			Application.LoadLevel(Application.loadedLevel);

			//Application.loadedLevel(1);
		}
		if (GUI.Button (new Rect (850, 700, 120, 30), "Exit")) { 
			//print(text); 
			//print(rgx.IsMatch(text)); 
			Application.Quit ();
		}

				
		// Make a background box 
		GUI.Box(new Rect(1100,20,250,500), "OPTIONS"); 
		
		//Make the first button. If it is pressed, Application.Loadlevel (1) will be executed 
		GUI.Box (new Rect (1120, 50, 210, 50),"Forward; Moving 1 step forward,\nthe function is called farward;") ;

		GUI.Box (new Rect (1120, 130, 210, 50),"Backward; Moving 1 step \nbackward,the function is called backward;") ;

		GUI.Box (new Rect (1120, 210, 210, 50),"Right; Moving 1 step to right,\nthe function is called right;") ;

		GUI.Box (new Rect (1120, 290, 210, 50),"Left; Moving 1 step left,\nthe function is called left;") ;

		GUI.Box (new Rect (1120, 370, 210, 50),"Jump; Jump 1 step forward,\nthe function is called jump;") ;


		
	}


}