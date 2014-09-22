using UnityEngine;
using System.Collections;

public class CFourCubeState : CState{

	public override void enter(GameObject obj){
		
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.parent = obj.transform;
		cube.AddComponent ("CCube");
		cube.name = "Cube";
		cube.renderer.material.color = Color.blue;
		cube.transform.position = new Vector3 (obj.transform.position.x + 1, obj.transform.position.y - 2, obj.transform.position.z);
		
		CPlayer script = (CPlayer)obj.GetComponent (typeof(CPlayer));
		script.m_aCubes.Add (cube);
		
	}
	
	public override void exit(GameObject obj){
		
	}
	
	public override void update(){
	}
}
