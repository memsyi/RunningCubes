using UnityEngine;
using System.Collections;

public class CBarrier : MonoBehaviour {
	protected ArrayList m_aQuads;
	protected bool m_bStopGlint = false;

	public int m_nRows = 9;
	public int m_nCols = 9;
	public float m_fStartPosX = -4f;
	public float m_fStartPosY = -4f;


	// Use this for initialization
	void Start () {
		createQuads();
		startGlint ();
	}

	void Awake () {
		m_aQuads = new ArrayList ();
	}

	void createQuads(){

		GameObject quad;

		for (int i = 0; i < m_nRows; i ++)
			for (int j = 0; j < m_nCols; j ++) {
				quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
				quad.AddComponent("CQuad");
				quad.transform.parent = transform;
				quad.transform.position = new Vector3(m_fStartPosX + j, m_fStartPosY + i, 0);
				quad.transform.position += transform.position;
		//		quad.collider.enabled = false;
				m_aQuads.Add(quad);
			}

	}

	void createMask (){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		CPlayer script = (CPlayer)player.GetComponent (typeof(CPlayer));

		ArrayList aCubes = script.m_aCubes;
		for (int i = 0; i < aCubes.Count; i ++) {
			GameObject cube = (GameObject)aCubes [i];
			CCube cube_script = (CCube) cube.GetComponent(typeof(CCube));

			int nRows = (int)(cube_script.m_NoChangePos.y - 0.5f);
			int nCols = (int)(cube_script.m_NoChangePos.x - m_fStartPosX);
			int index = nRows * m_nCols + nCols;
			GameObject quad = (GameObject)m_aQuads [index];
			quad.renderer.enabled = false;
			quad.collider.isTrigger = true;

		}

		
	}

	public void startGlint(){
		for (int i = 0; i < m_aQuads.Count; i ++) {
			GameObject quad = (GameObject) m_aQuads[i];
			CQuad script = (CQuad) quad.GetComponent(typeof(CQuad));
			script.m_bGlint = true;
		}

		m_bStopGlint = true;
//		InvokeRepeating("stopGlint", 1,5);
		int range = Random.Range (0, 3);
		switch (range) {
			case 0:
				transform.Rotate(0, 0, 90);
				break;
			case 1:
				transform.Rotate(0, 0, 180);
				break;
			case 2:
				transform.Rotate(0, 0, 270);
				break;
			case 3:
				transform.Rotate(0, 0, 360);
				break;
		}

	}

	void stopGlint(){
		for (int i = 0; i < m_aQuads.Count; i ++) {
			GameObject quad = (GameObject) m_aQuads[i];
			CQuad script = (CQuad) quad.GetComponent(typeof(CQuad));
			script.m_bGlint = false;

		}
		createMask ();
		m_bStopGlint = false;
//		CancelInvoke ();
	}
	

	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		float distance = transform.position.z - player.transform.position.z;

		if (distance < 90 && m_bStopGlint) {
			stopGlint();
		}
	}
}
