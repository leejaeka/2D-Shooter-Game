﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class rarm_gun_point : MonoBehaviour
{
    public Transform shotPoint;
    private Transform knight;
    // Update is called once per frame
    private void Start()
    {
        knight = GameObject.Find("knight").transform;
    }
    // Update is called once per frame
    private void Update()
    {
        Vector2 direction = knight.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle+30, Vector3.forward);
        transform.rotation = rotation;
    }

}
