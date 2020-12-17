using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public string levelName;
	bool passed;


	void Start()
	{
		passed = false;
	}
	void Update()
	{
		//print("Passed: " + passed);
		if (Input.GetKeyDown("return")&&passed) {
			if(!levelName.Equals("")) SceneManager.LoadScene(levelName);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			passed = true;
			GameManager.GetInstance().NailedIt();
		}
	}
}
