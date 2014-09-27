using UnityEngine;
using System.Collections;

public class CState {

	public GameObject m_Player;
	public CPlayer m_script;	

	public virtual void enter(GameObject obj){}

	public virtual void exit(GameObject obj){}

	public virtual void update(){}

}
