using UnityEngine;
using System.Collections;

public class CPlayer : MonoBehaviour {
	public float m_fMovespeed = 20f;
	public bool m_bRotate = false;
	public int m_nRotateRange = 0;
	public ArrayList m_aCubes;
	public int m_nScore = 0;
	protected CState m_state;
	// Use this for initialization
	void Start () {
//		setVelocity (m_fMovespeed);

	}
	

	void Awake () {
		m_aCubes = new ArrayList ();
		CState state = new CTwoCubeState ();
		setState(state);

	}
	
	public void setState(CState state){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (m_state != null) {
			m_state.exit(player);
		}
		if (state != null) {
			state.enter(player);
			m_state = state;
		}

	}

	public void setVelocity(float fVelocity){
		rigidbody.velocity = new Vector3 (0, 0, fVelocity);

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
//		m_nScore ++;

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
		if (m_nRotateRange % 90 == 0) {
			m_bRotate = false;
			m_nRotateRange = 0;
		}
	}
	// Update is called once per frame
	void Update () {
		rotate ();
		if (Input.GetMouseButtonDown (0))
			m_bRotate = true;
		if (m_state != null)
			m_state.update ();
	}

	void OnGUI(){
		string strScore = m_nScore.ToString ();
		GUI.Label(new Rect(10, 10, 100, 20), strScore);

	}
}
