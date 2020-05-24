using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public Weapon_point weaponToEquip;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<knight>().AddWeapon(weaponToEquip);

        }
    }
}
//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
