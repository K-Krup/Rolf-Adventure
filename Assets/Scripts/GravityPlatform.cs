using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
	Animator animator;
	bool isOn;

	void Start()
    {
		animator = GetComponent<Animator>();
    }

	public void TurnOn()
	{
		isOn = true;
		animator.SetBool("buttonPressed", true);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (isOn) { 
			if (col.gameObject.tag == "Player")
			{
				col.gameObject.GetComponent<Rolf>().Fly(-1.3f);
			}
		}	
	}
	private void OnTriggerExit2D(Collider2D col)
	{
		if (isOn)
		{
			if (col.gameObject.tag == "Player")
			{
				col.gameObject.GetComponent<Rolf>().Fall();
			}
		}
	}
}
