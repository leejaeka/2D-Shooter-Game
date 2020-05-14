using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_point : MonoBehaviour
{


    // Update is called once per frame
    private void Update()
    {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 80, Vector3.forward);
            transform.rotation = rotation;
    }

}
