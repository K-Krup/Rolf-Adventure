using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
	Animator animator;

	void Start()
    {
		animator = GetComponent<Animator>();

    }

	private void OnTriggerEnter2D(Collider2D collider)
	{
		print("Collision with trigger");
		if(collider.gameObject.tag == "GooPath")
		{
			collider.transform.SetParent(transform);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.collider.transform.SetParent(transform);
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.collider.transform.SetParent(null);
			animator = GetComponent<Animator>();
		}
	}

	public void TurnOn()
	{
		animator.SetBool("buttonPressed", true);
		
	}
}
