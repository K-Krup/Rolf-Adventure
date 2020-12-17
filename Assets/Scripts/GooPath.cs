using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooPath : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D col)
	{
		/*print("jest");
		if (col.gameObject.tag == "Platform")
		{
			for(int i =0; i < col.contactCount; i++)
			{ 
				print("Point "+i+": "+ col.contacts[i].point.x +" , "+ col.contacts[i].point.y);
			}
		}*/

		//print("Collision with "+col.gameObject.tag);
		if (col.gameObject.tag == "Platform")
		{
			print("Collision with platform");
		}
	}
}
