using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
	public float speed = 650;
	private Rigidbody2D rb;
	public float damage = 30;
	public LaserExplosion le;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		rb.velocity = transform.right * speed * Time.deltaTime;
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.contacts.Length > 0)
		{
			Instantiate(le, new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y), transform.rotation);
		}
		
			if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<Rolf>().GetHit(damage);
		}

		Destroy(gameObject);
	}

	
}
