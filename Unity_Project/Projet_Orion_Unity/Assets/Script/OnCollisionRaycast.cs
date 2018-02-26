using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Permissions;
using UnityEngine;

public class OnCollisionRaycast : MonoBehaviour
{
	public Transform t;

	private RaycastHit hit;
	
	
	// Update is called once per frame
	void Update ()
	{
//		Vector3 dir = Vector3.zero;
//		float rot = transform.rotation.eulerAngles.y;
//		
//		if (rot == 0)
//			dir = Vector3.forward;
//		else if (rot == 90)
//			dir = Vector3.right;
//		else if (rot == 180)
//			dir = Vector3.back;
//		else 
//			dir = Vector3.left;
		
//		Debug.Log(dir);

		bool hasHit = Physics.Raycast(transform.position, Vector3.back, out hit, 1f);
		
		Debug.Log(hasHit + ", tag : " + hit.collider.tag + ", Name : " + hit.collider.name);
		
		if (hasHit)
		{
			if (hit.collider.tag == "Wall")
			{
				Debug.Log("A Wall");
				t.Rotate(-90, 0, 0);
			}
			else if (hit.collider.tag == "Ground")
			{
				Debug.Log("The ground");
				t.Rotate(-90, 0, 0);
			}
		}
	}
}
