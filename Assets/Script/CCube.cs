using UnityEngine;
using System.Collections;

public class CCube : MonoBehaviour {
	public float m_fMovespeed =10f;
	public bool m_bRotate = false;
	public int m_nRotateRange = 0;
	// Use this for initialization
	void Start () {
		BoxCollider collider = (BoxCollider)GetComponent ("BoxCollider");
		collider.size = new Vector3(0.5f,0.5f,0.5f);
//		renderer.enabled = false;
//
//		var material = new PhysicMaterial();
//		material.dynamicFriction = 0;
//		material.staticFriction = 0;
//		collider.material = material;
	}

	public void rotate () {
		transform.Rotate (30, 0, 0);
		m_nRotateRange += 10;

	}
	
	// Update is called once per frame
	void Update () {
//		rotate ();
	}
}
