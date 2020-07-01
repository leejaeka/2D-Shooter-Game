using System;
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
	public int posi;
    public float attackRange;
	public float speed;
	public Transform player;
	public float stopDistance;
    public float attackSpeed;
    public int damage;
    public float attackCd;
    private float attackTime;
    private bool isGoingBack;
    public Transform hushtail;
	// Update is called once per frame
	void Start()
    {
        isGoingBack = false;
    }
	void Update()
	{
        if (player != null)
        {
            
            if (Vector2.Distance(transform.position, player.position) <= attackRange && Vector2.Distance(transform.position, player.position) > stopDistance && !isGoingBack && Time.time >= attackTime)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                //anim.SetBool("isRunning", true);
            } else if(Vector2.Distance(transform.position, player.position) <= stopDistance && !isGoingBack)
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + attackCd;
                    isGoingBack = true;
                }
            } else
            {
                if (Vector2.Distance(transform.position, centerPoint.position)<= 5)
                {
                    isGoingBack = !isGoingBack;
                }
                timer += Time.deltaTime * rotSpeed;
                moveBackToOrbit(20);
            }
        }else
        {
			timer += Time.deltaTime * rotSpeed;
			Rotate();
		}
        
	}

    IEnumerator Attack()
    {
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;
        float percent = 0;
        while (percent <= 1)
        {
            //anim.SetBool("isAttacking", true);
            percent += Time.deltaTime * attackSpeed;
            // for animating attack 
            float formula = (-Mathf.Pow(percent, 2) + percent) * 2;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
        //anim.SetBool("isAttacking", false);
        if (player.GetComponent<knight>().isParrying)
        {
            isGoingBack = true;
            hushtail.GetComponent<hushtail>().TakeDamage(damage);

        }
        else
        {
            player.GetComponent<knight>().TakeDamage(damage);
        }


    }

    void moveBackToOrbit(int speeed)
    {
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer * posi) * xSpread;
            float y = Mathf.Sin(timer * posi) * ySpread;
            Vector3 pos = new Vector3(x, y, zOffset);
            transform.position = Vector2.MoveTowards(transform.position, pos + centerPoint.position, speeed * Time.deltaTime);
        } else
        {
            float x = Mathf.Cos(timer * posi) * xSpread;
            float y = Mathf.Sin(timer * posi) * ySpread;
            Vector3 pos = new Vector3(x, y, zOffset);
            transform.position = Vector2.MoveTowards(transform.position, pos + centerPoint.position, speeed * Time.deltaTime);
        }
            
    }

    void Rotate()
	{
		if (rotateClockwise)
		{
			float x = -Mathf.Cos(timer*posi) * xSpread;
			float y = Mathf.Sin(timer*posi) * ySpread;
			Vector3 pos = new Vector3(x, y, zOffset);
			transform.position = pos + centerPoint.position;
		}
		else
		{
			float x = Mathf.Cos(timer*posi) * xSpread ;
			float y = Mathf.Sin(timer*posi) * ySpread ;
			Vector3 pos = new Vector3(x, y, zOffset);
			transform.position = pos + centerPoint.position;
		}
	}
}
