using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{

	public Laser laser;
	public bool actionl = false;
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			laser.isOn = actionl;
			animator.SetBool("buttonPressed", true);
			
		}
	}
}

