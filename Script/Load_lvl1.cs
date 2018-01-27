using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_lvl1 : MonoBehaviour {

	public void LoadScene(int lvl)
	{
		SceneManager.LoadScene(lvl);
	}

}
