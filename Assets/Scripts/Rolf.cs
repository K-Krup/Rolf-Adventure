using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rolf : MonoBehaviour
{

	public float speed = 400;
	public float jumpSpeed = 200;
	private Rigidbody2D rb;
	private bool isGrounded = true;
	private float xDisplacement;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	public GooPath prefab;
	public Transform pathSpawn;
	public float decayCoof = 0.015f;

	private Animator animator;
	private bool onGoo = false;

	public CameraShake cameraShake;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		prefab.transform.localScale = new Vector3(1f, 1f, 0f);
	}


	void Update()
	{

		if(transform.localScale.x<0.3f)
		{
			Die();
		}


		xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			rb.AddForce(new Vector2(0, jumpSpeed));
			isGrounded = false;
		}


		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

		animator.SetFloat("runSpeed", Mathf.Abs(rb.velocity.x));
		animator.SetFloat("jumpSpeed", rb.velocity.y);

		if (rb.velocity.x < 0)
		{
			transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
		}
		else if (rb.velocity.x > 0)
		{
			transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
		}

	}
	public void SetOnGoo(bool val)
	{
		onGoo = val;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		animator.SetTrigger("grounded");
		isGrounded = true;
		if (col.gameObject.tag == "GooPath") onGoo = true;

		if (col.gameObject.tag == "Platform")
		{
			if (col.contacts.Length > 0)
			{
				if (onGoo == false)
				{
					Decay(col.contacts[0].point.x, col.contacts[0].point.y);
				}
			}

		}

	}
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Platform")
		{
			if (col.contacts.Length > 0)
			{

				if (onGoo == false)
				{
					Decay(col.contacts[0].point.x, col.contacts[0].point.y);
				}
			}

		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "GooPath") onGoo = false;
	}


	void Decay(float x, float y)
	{
		Vector3 center = transform.position;
		Vector3 colPoint = new Vector3(x-center.x, y-center.y);
		Vector3 pathPoint = new Vector3(pathSpawn.transform.position.x-center.x, pathSpawn.transform.position.x-center.x);

		float angle = Mathf.Atan2(colPoint.y, colPoint.x) * Mathf.Rad2Deg;
		angle += 90;
	

		angle = Mathf.Round(angle / 90) * 90;

		
		

		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		

		Instantiate(prefab, new Vector3(x, y), rotation);

		transform.localScale -= new Vector3(decayCoof/3, decayCoof/3, 0f);
		prefab.transform.localScale -= new Vector3(decayCoof/3, 0f, 0f);
		speed -= decayCoof * 30;
	
	}



	public void GetHit(float damage)
	{
		transform.localScale -= new Vector3(decayCoof*damage, decayCoof*damage, 0f);
		prefab.transform.localScale -= new Vector3(decayCoof*damage/3, 0f, 0f);
		speed -= decayCoof * 30*damage;
		cameraShake.ShakeIt(damage);
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "GooPath")
		{
			onGoo = true;

		}

	}

	void OnStayEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "GooPath") onGoo = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "GooPath") onGoo = false;
	}

	public void Fly(float gs)
	{
		rb.gravityScale = gs;
	}
	public void Fall()
	{
		rb.gravityScale = 1;
	}

	void Die()
	{
		Destroy(gameObject);
		GameManager.GetInstance().GameOver();
	}
}

