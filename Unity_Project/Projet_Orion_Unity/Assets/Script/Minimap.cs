using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

	public Camera Map;
	public bool MapActive = true;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			MapActive = !MapActive;
			Map.GetComponent<Camera>().enabled = MapActive;
		}

	}
}
