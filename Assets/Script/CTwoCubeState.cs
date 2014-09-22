using UnityEngine;
using System.Collections;

public class CTwoCubeState : CState {
	
	public override void enter(GameObject obj){

		for (int i = 0; i < 2; i ++) {
			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.parent = obj.transform;
			cube.AddComponent ("CCube");
			cube.name = "Cube";
			cube.renderer.material.color = Color.blue;
			cube.transform.position = new Vector3 (obj.transform.position.x , obj.transform.position.y - i, obj.transform.position.z);

			CPlayer script = (CPlayer)obj.GetComponent (typeof(CPlayer));
			script.m_aCubes.Add (cube);
		}

	}

	public override void exit(GameObject obj){

	}

	public override void update(){
	}

}
