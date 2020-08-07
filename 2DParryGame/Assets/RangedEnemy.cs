using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;
    private Animator anim;
    public Transform shotPoint;
    public GameObject bullet;
    public Transform knight;
    public GameObject audioSrc;
    public float initialTime;
    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        audioSrc = GameObject.Find("AudioController");
        initialTime = Random.Range(0.0f, 2.0f);
    }


    // Update is called once per frame
    void Update()
    {
        if(player!= null)
        {
            knight = GameObject.Find("knight").transform;
            //if sight range{
            anim.SetBool("inRange", true);
            //}
            if (Vector2.Distance(transform.position, knight.position) > stopDistance)
            {
                anim.SetBool("inRange", true);
                transform.position = Vector2.MoveTowards(transform.position, knight.position,speed*Time.fixedDeltaTime);
            }
            else
            {
                anim.SetBool("inRange", true);
                transform.position = Vector2.MoveTowards(transform.position, knight.position, 1* Time.fixedDeltaTime);
            }

            if (Time.time >= initialTime && Time.time >= attackTime)
            {

                attackTime = Time.time + timeBetweenAttack;
                RangedAttack();

            }
        }    
    }
    public void RangedAttack()
    {
        Vector2 direction = knight.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        audioSrc.GetComponent<AudioControl>().playSound("penguin_bang");

    }
}
