using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButton : MonoBehaviour
{
	public ButtonPlatform bPlatform;
	public GravityPlatform gPlatform;
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			animator.SetBool("buttonPressed", true);
			if (bPlatform!=null) bPlatform.TurnOn();
			if (gPlatform != null) gPlatform.TurnOn();
		}
	}
}
