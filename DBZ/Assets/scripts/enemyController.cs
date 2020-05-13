using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public float velocity = 1.5f;
    private Animator animator;
    private Rigidbody2D rb2d;
    public GameObject bullet;
    private Transform _firePoint;
    //audio
    public AudioClip bullet2;
    public AudioClip EnemyDie;
    AudioSource bullet2Player;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        _firePoint = transform.Find("firePoint");
      
         animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.left * velocity;
        animator = GetComponent<Animator>();
        InvokeRepeating("Shoot", 1f, 3.5f);
        InvokeRepeating("Fast", 1f, 3f);

        bullet2Player = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
         
        }
    }
    void Shoot()
    {
       
        GameObject myBullet = Instantiate(bullet, _firePoint.position, Quaternion.identity);
        BulletController bulletComponent = myBullet.GetComponent<BulletController>();
        bulletComponent.direction = Vector2.left;

        bullet2Player.clip = bullet2;
        bullet2Player.Play();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UpdateState("EnemyAttack1");

        }
        if (other.gameObject.tag == "Ball")
        {
           
            UpdateState("EnemyDie1");
            Invoke("Kill", 0.5f);

            bullet2Player.clip = EnemyDie;
            bullet2Player.Play();
            
        }

        if (other.gameObject.tag == "Destroyer" )
        {
            Destroy(gameObject);
        }
      
    }
    void Fast()
    {
        velocity =+ 0.5f;
    }
    void Kill()
    {
        Destroy(gameObject);
    }
   
}

