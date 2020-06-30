using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour
{
    public bool rotateClockwise;
    public float radius;
    public Transform centerPoint;
    public float rotSpeed;
	float timer = 0;
	public float xSpread;
	public float ySpread;
	public float zOffset;
	public float waitTime;
	// Update is called once per frame
	void Start()
    {

    }
	void Update()
	{
		if (Time.time >= waitTime)
        {
			timer += Time.deltaTime * rotSpeed;
			Rotate();
        }
		
	}

	void Rotate()
	{
		if (rotateClockwise)
		{
			float x = -Mathf.Cos(timer) * xSpread;
			float y = Mathf.Sin(timer) * ySpread;
			Vector3 pos = new Vector3(x, y, zOffset);
			transform.position = pos + centerPoint.position;
		}
		else
		{
			float x = Mathf.Cos(timer) * xSpread;
			float y = Mathf.Sin(timer) * ySpread;
			Vector3 pos = new Vector3(x, y, zOffset);
			transform.position = pos + centerPoint.position;
		}
	}
}
