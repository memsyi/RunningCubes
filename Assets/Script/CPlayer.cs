using UnityEngine;
using System.Collections;

public class CPlayer : MonoBehaviour {
	public float m_fMovespeed =30f;
	public bool m_bRotate = false;
	public int m_nRotateRange = 0;
	public ArrayList m_aCubes;
	protected CState m_state;
	// Use this for initialization
	void Start () {
		Rigidbody rigidbody = (Rigidbody)GetComponent("Rigidbody");
		rigidbody.velocity = new Vector3 (0, 0, 20.0f);
//		rigidbody.AddForce(new Vector3 (0, 0, 5.0f));

	}

	void Awake () {
		m_aCubes = new ArrayList ();
		CState state = new CTwoCubeState ();
		setState(state);
//		CState state1 = new CThreeCubeState ();
//		setState(state1);
//		CState state2 = new CFourCubeState ();
//		setState(state2);
	}
	
	void setState(CState state){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (m_state != null) {
			m_state.exit(player);
		}
		if (state != null) {
			state.enter(player);
			m_state = state;
		}

	}

	void OnCollisionEnter(Collision other) {
//		GameObject barrier = other.transform.parent.gameObject;
//		CBarrier script = (CBarrier)barrier.GetComponent (typeof(CBarrier));
//		script.startGlint ();
		Debug.Log ("collision");
	}

		void OnTriggerExit(Collider other) {
//				GameObject barrier = other.transform.parent.gameObject;
//				CBarrier script = (CBarrier)barrier.GetComponent (typeof(CBarrier));
//				script.startGlint ();
		Debug.Log ("trigger");
	}
	
	void rotate () {
		if (m_bRotate) {
			transform.Rotate (0, 0, 30);
			m_nRotateRange += 30;
			for (int i = 0; i < m_aCubes.Count; i ++){
				GameObject g = (GameObject)m_aCubes[i];
				CCube script = (CCube) g.GetComponent(typeof(CCube));
				script.rotate();
			}

		}
		if (m_nRotateRange % 90 == 0)
			m_bRotate = false;
	}
	// Update is called once per frame
	void Update () {
//		transform.Translate(Vector3.forward * m_fMovespeed*Time.deltaTime);
		rotate ();
		if (Input.GetMouseButtonDown (0))
			m_bRotate = true;
	}
}
