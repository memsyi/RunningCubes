using UnityEngine;
using System.Collections;

public class CTwoCubeState : CState {
	
	public override void enter(GameObject obj){
		m_Player = obj;
		m_script = (CPlayer)m_Player.GetComponent (typeof(CPlayer));
		m_script.setVelocity (60);
		for (int i = 0; i < 2; i ++) {
			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.parent = obj.transform;
			cube.AddComponent ("CCube");
			cube.name = "Cube";
			cube.renderer.material.color = Color.blue;
			cube.transform.localPosition = new Vector3 (0 , 0 - i, 0);

			CPlayer script = (CPlayer)obj.GetComponent (typeof(CPlayer));
			script.m_aCubes.Add (cube);
		}

	}

	public override void exit(GameObject obj){

	}

	public override void update(){
		if (m_script.m_nScore > 5) {
			CState state = new CThreeCubeState ();
			m_script.setState(state);
		}
	}

}
