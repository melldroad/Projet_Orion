using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Permissions;
using UnityEngine;

public class OnCollisionRaycast : MonoBehaviour
{
	//public Transform t;

	private Vector3 raycastDir = Vector3.down;
	private RaycastHit hit;
	
	
	// Update is called once per frame
	/*void Update ()
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
	}*/

	void FixedUpdate()
	{
		bool hasHit = Physics.Raycast(transform.position, raycastDir, out hit, 10f);
		if (hasHit)
			Debug.Log("Has hit : " + hasHit + ", tag : " + hit.collider.tag + ", Name : " + hit.collider.name + ", Distance : " + hit.distance);
			
		if (!hasHit)
		{
			Debug.Log(hasHit);
			transform.Rotate(-90, 0, 0);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		Debug.Log("COLISION !!!");
		if (other.collider.tag == "Wall")
		{
			raycastDir = new Vector3();
			Debug.Log("I hit a wall");
			transform.rotation = Quaternion.Euler(-90, transform.rotation.eulerAngles.y, 0);
			raycastDir = transform.eulerAngles;
		}
		else if (other.collider.tag == "Ground")
		{
			raycastDir = Vector3.down;
			Debug.Log("This is the ground");
			transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
		}
	}

	private void NullFunc()
	{
		/*if (other.collider.tag == "Ceiling")
		{
			Debug.Log(transform.rotation.eulerAngles.y);
			transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
			Debug.Log(transform.rotation.eulerAngles);
		}
		else if (other.collider.tag == "Rewall")
		{
			transform.Rotate(90, 0, 0);
		}*/
	}
}
