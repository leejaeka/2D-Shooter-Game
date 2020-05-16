using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlime : Enemy
{
    public float stopDistance;
    private float attackTime;
    public float attackSpeed;
    private Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if(Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttack;
                }
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
}
