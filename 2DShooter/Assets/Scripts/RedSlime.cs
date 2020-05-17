using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RedSlime : Enemy
{
    public float stopDistance;
    public float summonStopDistance;
    private float attackTime;
    public float attackSpeed;
    private Animator anim;
    private Rigidbody2D rb;
    public Enemy enemyToSummon;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private Vector2 targetPosition;
    public float timeBetweenSummons;
    private float summonTime;
    // Start is called before the first frame update
    public override void Start()
    {
        anim = GetComponent<Animator>();
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        

    }
    // Update is called once per frame
    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > summonStopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }
            else if(Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                if (Time.time >= summonTime)
                {
                    anim.SetTrigger("summon");
                    summonTime = Time.time + timeBetweenSummons;
                    
                } else
                {   
                    anim.SetBool("isRunning", true);
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
            } else
            {      
                anim.SetBool("isRunning", false);
                if (Time.time >= summonTime)
                {
                    anim.SetTrigger("summon");
                    summonTime = Time.time + timeBetweenSummons;

                }
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttack;
                }          
            }
        }
    }

    public void Summon() {
        if (player != null)
        {
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    }

        

    IEnumerator Attack()
    {
        player.GetComponent<knight>().TakeDamage(damage);
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;
        float percent = 0;
        while (percent <= 1)
        {
            anim.SetBool("isAttacking", true);
            percent += Time.deltaTime * attackSpeed;
            // for animating attack 
            float formula = (-Mathf.Pow(percent, 2) + percent) * 2;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }


                anim.SetBool("isAttacking", false); 
    }
}

