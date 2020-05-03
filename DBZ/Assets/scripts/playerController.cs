using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float contador = 0;
    public GameObject Player;
    public GameObject life;
    public GameObject uiGOver;
    private Animator animator;
    public bool grounded = false;
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
        // if (grounded == true && Input.GetMouseButtonDown(0))
        //{

       //     UpdateState("GohanSalto");
       //  grounded = false;

       //}
       if(animator.GetBool("Attack") == true)
        {
            Invoke("Shoot",0.5f);
            animator.SetBool("Attack", false);
        }
  
    }
    void Shoot()
    {
       // if(bolaki !=null && _firePoint != null && Player !=null)
        //{
            GameObject myBall = Instantiate(bolaki, _firePoint.position, Quaternion.identity);
            ballController BallComponent = myBall.GetComponent<ballController>();
           
        //}
    }
    public void UpdateState(string state = null)
    {
        if(state != null)
        {
            animator.Play(state);
            grounded = false;
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
        if (other.gameObject.tag == "Plataforma")
        {
            grounded = true;
           
        }
      
        if (other.gameObject.tag == "Enemy")
        {
            UpdateState("PlayerDamage");
            contador++;
            
            if(contador != 0) {
                string actualizar = "TouchLife" + contador;
               
                life.SendMessage("UpdateState", actualizar);
                if(actualizar == "TouchLife6")
                {
                    UpdateState("PlayerDie");
                    uiGOver.SetActive(true);
                   
                }
            }
        }
        
        

    }
}
