using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	public float period = 1;
	private float lastBallTime;

	public Transform target;
	public LaserBeam prefab;
	public Transform LaserBase;
	public Transform shootingPoint;

	public bool isOn=true;
	bool detected;

	public float rotationSpeed = 5f;

	void Start()
	{
		lastBallTime = 0;
		//detected = true;
	}

	void Update()
	{
		if (target!=null)
		{
			if (detected&&isOn)
			{
				Vector2 direction = target.position - transform.position;
				float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

				

				float lbAngle = LaserBase.rotation.z * 180;
				

				if (angle > -190+lbAngle & angle < 10+lbAngle)
				{
					Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
					transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
					lastBallTime += Time.deltaTime;
					if (lastBallTime > period)
					{
						lastBallTime = 0;
						Instantiate(prefab, shootingPoint.position, shootingPoint.rotation);
					}
				}
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			detected = true;
		}
	}
	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			detected = false;
		}
	}
}
