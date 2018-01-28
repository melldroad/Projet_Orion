using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Mouvement : MonoBehaviour
{

	#region Public_Var

	public List<Transform> Bodys = new List<Transform>();
    
	public float Mindistance;
	public float Speed;
	//public float RotationSpeed;

	public int Snake_Lenght_At_Start;

	public KeyCode Forward;
	public KeyCode Left;
	public KeyCode Right;
	public KeyCode AddBodyKey;
    
	public string Body;
	public string Tail;

	#endregion

	#region PrivateVar

	private float distance;
	private Transform curBody;
	private Transform prevBody;

	#endregion
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Snake_Lenght_At_Start - 1; i++)
		{
			AddBody();
		}
		
		Transform newTail = PhotonNetwork.Instantiate(Tail, Bodys[Bodys.Count - 1].position, Bodys[Bodys.Count - 1].rotation, 0).transform;
		newTail.SetParent(transform);
		Bodys.Add(newTail);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move();

		if (Input.GetKeyDown(AddBodyKey))
		{
			AddBody();
		}
	}

	public void Move()
	{
		float curSpeed = Speed;

		if (Input.GetKey(Forward))
			curSpeed *= 2;

		Bodys[0].Translate(Bodys[0].forward * curSpeed * Time.deltaTime, Space.World);
		
		if (Input.GetKeyDown(Right))
			Bodys[0].Rotate(Vector3.up * 90);
		else if (Input.GetKeyDown(Left))
			Bodys[0].Rotate(Vector3.up * -90);


		for (int i = 1; i < Bodys.Count; i++)
		{
			curBody = Bodys[i];
			prevBody = Bodys[i - 1];

			distance = Vector3.Distance(prevBody.position, curBody.position);

			Vector3 nextpos = prevBody.position;
			//nextpos.y = Bodys[0].position.y;

			float T = Time.deltaTime * distance / Mindistance * curSpeed;

			if (T > .5f)
				T = .5f;

			curBody.position = Vector3.Slerp(curBody.position, nextpos, T);
			curBody.rotation = Quaternion.Slerp(curBody.rotation, prevBody.rotation, T);
		}
	}

	public void AddBody()
	{
		if (Bodys.Count > Snake_Lenght_At_Start)
		{
			Transform newBody = PhotonNetwork.Instantiate(Body, Bodys[Bodys.Count - 2].position, Bodys[Bodys.Count - 2].rotation, 0).transform;
			newBody.SetParent(transform);
			Bodys.Add(newBody);
			Bodys[Bodys.Count - 1] = Bodys[Bodys.Count - 2];
			Bodys[Bodys.Count - 2] = newBody;
		}
		else
		{
			Transform newBody = PhotonNetwork.Instantiate(Body, Bodys[Bodys.Count - 1].position, Bodys[Bodys.Count - 1].rotation, 0).transform;
			newBody.SetParent(transform);
			Bodys.Add(newBody);
		}
	}
}
