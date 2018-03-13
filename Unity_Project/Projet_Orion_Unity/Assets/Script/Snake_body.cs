using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;


public class Snake_body : Snake_player
{
	public Vector3 Dir;
	public Vector3 ChangeDir;
	public float speed;
	
	// Use this for initialization
	void Start ()
	{
		if (Bodys.Count == 0)
			Dir = Direction;
		else
			Dir = Bodys[Bodys.Count - 1].Direction;
		speed = Speed;
		//ChangePos = transform;
		//speed = head.Speed;
		//spawn = head.Spawn;
	}
	
	// Update is called once per frame
	void Update ()
	{/*
		ChangeDir = ChangePos;
		mouvement();
		*/
	}

	public void mouvement()
	{
		if (transform.position.x <= ChangePos.x - 0.1 && transform.position.x >= ChangePos.x +0.1
		    			&& transform.position.y <= ChangePos.y - 0.1 && transform.position.y >= ChangePos.y +0.1)
			Dir = Direction;
		transform.Translate(Dir * Time.deltaTime * Speed);
	}

	public bool Eat(GameObject obj)
	{
		if (obj.tag == "Eatable")
		{
			//create_body();
			return true;
		}
		return false;
	}

	private void OnTriggerEnter(Collider other)
	{
		bool eatable = Eat(other.gameObject);
	}

	/*public void CreateBody()
	{
		Debug.Log("Create");
		if (head.Bodys.Count == 0)
		{
			Debug.Log("Instance");
			Instantiate(spawn, head.transform.position + 2.5f * -Dir, Quaternion.identity);
		}
		else
		{
			Debug.Log("Body");
			Instantiate(spawn, Bodys[Bodys.Count - 1].transform.position + 2.5f * -Dir, Quaternion.identity);
		}
	}*/
}
