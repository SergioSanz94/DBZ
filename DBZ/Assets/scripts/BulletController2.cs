﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController2 : MonoBehaviour
{
    public float speed = 4f;
    public Vector2 direction;
    public float livingTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

}
