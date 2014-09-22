using UnityEngine;
using System.Collections;

public class bgtrigger : MonoBehaviour {
	public float m_fMovespeed =10f;

	// Use this for initialization
	GameObject bg;
	void Start()
	{

	}
	void OnTriggerEnter(Collider e)
	{

		if (e.CompareTag ("Player")) {
			if (transform.parent.CompareTag ("bg2")) {//父类
					bg = GameObject.FindGameObjectWithTag ("bg2");
					bg.transform.position = new Vector3 (0, 0, bg.transform.position.z + 200);
					resetQuad();

			} if(transform.parent.CompareTag ("bg1")) {
				bg = GameObject.FindGameObjectWithTag ("bg1");
				bg.transform.position = new Vector3 (0, 0, bg.transform.position.z + 200);
				resetQuad();
			}
		}
	}

	void resetQuad(){
		GameObject bg = transform.parent.gameObject;
		GameObject barrier = bg.transform.FindChild ("Barrier").gameObject;
		CBarrier script = (CBarrier)barrier.GetComponent (typeof(CBarrier));
		script.startGlint ();
	}
	
	// Update is called once per frame
	void Update () {
//		transform.parent.transform.Translate(Vector3.back * m_fMovespeed*Time.deltaTime);
	}
}
