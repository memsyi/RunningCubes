using UnityEngine;
using System.Collections;

public class CFourCubeState : CState{

	public override void enter(GameObject obj){
		m_Player = obj;
		m_script = (CPlayer)m_Player.GetComponent (typeof(CPlayer));
		m_script.setVelocity(100f);

		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.parent = obj.transform;
		cube.AddComponent ("CCube");
		cube.name = "Cube";
		cube.renderer.material.color = Color.blue;
		cube.transform.localPosition = new Vector3 (2, 0, 0);
		
		CPlayer script = (CPlayer)obj.GetComponent (typeof(CPlayer));
		script.m_aCubes.Add (cube);
		
	}
	
	public override void exit(GameObject obj){
		
	}
	
	public override void update(){
	}
}
