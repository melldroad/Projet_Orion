using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snake_body : Snake_player
{
	public Transform _t;
	public Vector3 Direction;
	public Snake_player head;
	
	// Use this for initialization
	void Start ()
	{
		if (head.Bodys.Count == 0)
			Direction = head.Direction;
		else
			Direction = head.Bodys[Bodys.Count - 1].Direction;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
