using UnityEngine;
using System.Collections;

public class CFirstUI : MonoBehaviour {
	public Texture image;
	public GUISkin testSkin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		GUI.skin = testSkin;
		GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 3, 100, 100), "Running Cubes");
		if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 100, 100), image))
			Application.LoadLevel("GameScene") ;
	}

}
