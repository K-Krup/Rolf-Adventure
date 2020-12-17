using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLaser : MonoBehaviour
{
	public float period = 0.25f;
	private float lastBallTime;
	public LaserBeam prefab;

	public Transform shootingPoint;

	void Start()
	{
		lastBallTime = 0;
	}

	void Update()
	{
		lastBallTime += Time.deltaTime;
		if (lastBallTime > period)
		{
			lastBallTime = 0;
			Instantiate(prefab, shootingPoint.position, shootingPoint.rotation);
		}
	}
}
