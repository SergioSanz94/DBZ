﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float contador = 0;
    public GameObject enemy;
    public GameObject life;
    public GameObject game;
    public GameObject uiGOver;
    private Animator animator;
    public GameObject bolaki;
    public GameObject button;
    private Transform _firePoint;

   void Awake()
    {
      
        _firePoint = transform.Find("FirePoint");
    }
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (animator.GetBool("Attack") == true)
        {

            Invoke("Shoot",0.5f);
            animator.SetBool("Attack", false);
        }
  
    }
    void Shoot()
    {
   
            GameObject myBall = Instantiate(bolaki, _firePoint.position, Quaternion.identity);
            ballController BallComponent = myBall.GetComponent<ballController>();

    }

   
    public void UpdateState(string state = null)
    {
        if(state != null)
        {
            animator.Play(state);
            
        }
    }
    public void UpdateAttack(string attack = null)
    {
        if (attack != null)
        {
            animator.SetBool("Attack",true);
           
        }
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Bullet")
        {
            
            UpdateState("PlayerDamage");
            contador++;
            
            if(contador != 0) {
                string actualizar = "TouchLife" + contador;
               
                life.SendMessage("UpdateState", actualizar);
                if(actualizar == "TouchLife6")
                {
                    UpdateState("PlayerDie");
                    game.SendMessage("UpdateGame", "GameOver");
                    uiGOver.SetActive(true);
                    contador = 0;
                   
                }
            }
        }
        
      

    }
}
