using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake_player : MonoBehaviour
{

	public float Speed;
	public KeyCode Right;
	public KeyCode Left;
	public KeyCode Forward;
	public KeyCode Back;
	public Snake_body Spawn;
	public List<Snake_body> Bodys;
	
	public Vector3 ChangePos;
	public Vector3 Direction;
	public Vector3 Temp_Dir;
	

	private bool forward;
	private bool back;
	private bool left;
	private bool right;
	
	

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, 2.5f, 0);
		transform.rotation = Quaternion.Euler(0,0,0);
		forward = false;
		back = false;
		left = false;
		right = false;
		ChangePos = transform.position;
		Temp_Dir = Direction;
	}
	
	// Update is called once per frame
	void Update()
	{
		mouvement();
		//mouvement_body();
		if (Input.GetKeyDown(KeyCode.A))
			create_body();
		
		/*i += Time.deltaTime;
		if (i >= .5)
		{
			i = 0;
			create_body();
		}*/
	}

	public void mouvement()
	{
		if (Input.GetKeyDown(Forward) && Direction != Vector3.back && Direction != Vector3.forward)
		{
			Debug.Log(Direction);
			ChangePos = transform.position;
			forward = true;
			back = false;
			left = false;
			right = false;
		}
		else if (Input.GetKeyDown(Back) && Direction != Vector3.forward && Direction != Vector3.back)
		{
			Debug.Log(Direction);
			ChangePos = transform.position;
			forward = false;
			back = true;
			left = false;
			right = false;
		}
		else if (Input.GetKeyDown(Left) && Direction != Vector3.right && Direction != Vector3.left)
		{
			Debug.Log(Direction);
			ChangePos = transform.position;
			back = false;
			forward = false;
			left = true;
			right = false;
		}
		else if (Input.GetKeyDown(Right) && Direction != Vector3.left && Direction != Vector3.right)
		{
			Debug.Log(Direction);
			ChangePos = transform.position;
			back = false;
			forward = false;
			left = false;
			right = true;
		}
		
		if (forward && Direction != Vector3.back)
		{
		//	Debug.Log(Direction);
			Direction = Vector3.forward;
			//ChangePos = transform.position;
			transform.Translate(Vector3.forward * Time.deltaTime * Speed);
		}
		else if (back && Direction != Vector3.forward)
		{
			Direction = Vector3.back;
			//ChangePos = transform.position;
			transform.Translate(Vector3.back * Time.deltaTime * Speed);
		}
		else if (left && Direction != Vector3.right)
		{
			Direction = Vector3.left;
			//ChangePos = transform.position;
			transform.Translate(Vector3.left * Time.deltaTime * Speed);
		}
		else if (right && Direction != Vector3.left)
		{
			Direction = Vector3.right;
			//ChangePos = transform.position;
			transform.Translate(Vector3.right * Time.deltaTime * Speed);
		}
	}

	public void create_body()
	{
		Debug.Log("Create");
		if (Bodys.Count == 0)
		{
			Debug.Log("Instance");
			Bodys.Add(Instantiate(Spawn, transform.position + 2.5f * -Direction, Quaternion.identity));
			Temp_Dir = Direction;
		}
		else
		{
			Debug.Log("Body");
			Bodys.Add(Instantiate(Spawn, Bodys[Bodys.Count - 1].transform.position + 2.5f * -Bodys[Bodys.Count - 1].Direction, Quaternion.identity));
			Temp_Dir = Direction;
		}
	}
	
	public void mouvement_body()
	{
		for (int i = 0; i < Bodys.Count; i++)
		{
			Bodys[i].mouvement();
			/*if (Bodys[i].transform.position == ChangePos)
				Temp_Dir = Direction;
			Bodys[i].transform.Translate(Temp_Dir * Time.deltaTime * Speed);*/
		}
	}


}
