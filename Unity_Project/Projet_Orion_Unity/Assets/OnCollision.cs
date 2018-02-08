using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(UnityEngine.Collision other)
	{
		if (other.collider.tag == "Wall")
		{
			Debug.Log(transform.rotation.eulerAngles.y);
			transform.rotation = Quaternion.Euler(-90, transform.rotation.eulerAngles.y, 0);
		}
		else if (other.collider.tag == "Ground")
		{
			Debug.Log(transform.rotation.eulerAngles.y);
			transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
		}
		else if (other.collider.tag == "Ceiling")
		{
			Debug.Log(transform.rotation.eulerAngles.y);
			transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
			Debug.Log(transform.rotation.eulerAngles);
		}
		else if (other.collider.tag == "Rewall")
		{
			transform.Rotate(90, 0, 0);
		}
	}
}
