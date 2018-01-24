using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake_player : MonoBehaviour
{

	public int Speed;
	public float object_duration;
	public int snake_lenght;
	public KeyCode Right;
	public KeyCode Left;
	public KeyCode Forward;
	public KeyCode Back;
	public GameObject Spawn;
	public List<Snake_body> Bodys;
	
	public Vector3 Direction;
	

	private bool forward;
	private bool back;
	private bool left;
	private bool right;
	private float i = 0;
	

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, 2.5f, 0);
		transform.rotation = Quaternion.Euler(0,0,0);
		forward = false;
		back = false;
		left = false;
		right = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		mouvement();
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
			forward = true;
			back = false;
			left = false;
			right = false;
		}
		else if (Input.GetKeyDown(Back) && Direction != Vector3.forward && Direction != Vector3.back)
		{
			Debug.Log(Direction);
			forward = false;
			back = true;
			left = false;
			right = false;
		}
		else if (Input.GetKeyDown(Left) && Direction != Vector3.right && Direction != Vector3.left)
		{
			Debug.Log(Direction);
			back = false;
			forward = false;
			left = true;
			right = false;
		}
		else if (Input.GetKeyDown(Right) && Direction != Vector3.left && Direction != Vector3.right)
		{
			Debug.Log(Direction);
			back = false;
			forward = false;
			left = false;
			right = true;
		}
		
		if (forward && Direction != Vector3.back)
		{
		//	Debug.Log(Direction);
			Direction = Vector3.forward;
			transform.Translate(Vector3.forward * Time.deltaTime * Speed);
		}
		else if (back && Direction != Vector3.forward)
		{
			Direction = Vector3.back;
			transform.Translate(Vector3.back * Time.deltaTime * Speed);
		}
		else if (left && Direction != Vector3.right)
		{
			Direction = Vector3.left;
			transform.Translate(Vector3.left * Time.deltaTime * Speed);
		}
		else if (right && Direction != Vector3.left)
		{
			Direction = Vector3.right;
			transform.Translate(Vector3.right * Time.deltaTime * Speed);
		}
	}

	public void create_body()
	{
		Vector3 Pos;
		if (Bodys.Count == 0)
			//Pos = transform.position + 
		//Bodys.Add(Instantiate(Spawn, transform.position + ));
		//Bodys.Add(Instantiate(Spawn, transform.position + (2.5f + 2 * snake_lenght)  * -Direction + Vector3.up, Quaternion.identity));
		snake_lenght += 1;
	}


}
