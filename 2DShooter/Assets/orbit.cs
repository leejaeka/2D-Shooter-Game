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
	public float zSpread;
	public float yOffset;
	// Update is called once per frame
	void Start()
    {

    }
	void Update()
	{
		timer += Time.deltaTime * rotSpeed;
		Rotate();
	}

	void Rotate()
	{
		if (rotateClockwise)
		{
			float x = -Mathf.Cos(timer) * xSpread;
			float z = Mathf.Sin(timer) * zSpread;
			Vector3 pos = new Vector3(x, yOffset, z);
			transform.position = pos + centerPoint.position;
		}
		else
		{
			float x = Mathf.Cos(timer) * xSpread;
			float z = Mathf.Sin(timer) * zSpread;
			Vector3 pos = new Vector3(x, yOffset, z);
			transform.position = pos + centerPoint.position;
		}
	}
}
