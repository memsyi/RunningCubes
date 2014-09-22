using UnityEngine;
using System.Collections;

public class playControl : MonoBehaviour {
	public float movespeed =10f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow))
			transform.Translate(Vector3.forward * movespeed*Time.deltaTime);
		if (Input.GetKey(KeyCode.DownArrow))
			transform.Translate(Vector3.back * movespeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.LeftArrow))
			transform.Translate(Vector3.left * movespeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.RightArrow))
			transform.Translate(Vector3.right * movespeed * Time.deltaTime);
	}


}
