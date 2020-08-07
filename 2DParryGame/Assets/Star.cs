//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Star : MonoBehaviour
//{


//    public float speed;
//    //private Animator anim;
//    public Transform knight;
//    public GameObject audioSrc;
//    public float initialTime;
//    // Start is called before the first frame update
//    void Start()
//    {
//        base.Start();
//        //anim = GetComponent<Animator>();
//        audioSrc = GameObject.Find("AudioController");
//        initialTime = Random.Range(0.0f, 2.0f);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (player != null)
//        {
//            knight = GameObject.Find("knight").transform;
            
//            transform.position = Vector2.MoveTowards(transform.position, knight.position, speed * Time.fixedDeltaTime);

//        }
//    }
//}
