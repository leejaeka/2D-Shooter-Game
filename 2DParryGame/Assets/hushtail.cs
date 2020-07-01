using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class hushtail : Enemy
{
    public float stopDistance;
    public Transform[] fairies;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //fairies = new Enemy[5];
        foreach (Transform fairy in fairies)
        {
            fairy.GetComponent<orbit>().hushtail = transform;
            fairy.GetComponent<orbit>().player = player;
            fairy.GetComponent<orbit>().centerPoint = transform.GetChild(7);
            Instantiate(fairy, transform.position, transform.rotation);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                //anim.SetBool("isRunning", true);
            }
        }
    }
}
