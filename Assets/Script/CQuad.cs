using UnityEngine;
using System.Collections;

public class CQuad : MonoBehaviour {
	public bool m_bGlint = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (m_bGlint) {
			if (Random.Range(0,4) == 0){
				renderer.enabled = false;
				collider.isTrigger = true;
			}
			if (Random.Range(0,4) == 1){
				renderer.enabled = true;
				collider.isTrigger = false;
			}
		}
	}
}
