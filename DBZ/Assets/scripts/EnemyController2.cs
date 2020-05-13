using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController2 : MonoBehaviour
{
    public float velocity = 1.5f;
    private Animator animator;
    private Rigidbody2D rb2d;
    public GameObject bullet;
    private Transform _firePoint;

    // Start is called before the first frame update
    void Awake()
    {

        _firePoint = transform.Find("FirePoint");

        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.left * velocity;
        animator = GetComponent<Animator>();
        InvokeRepeating("Shoot", 2f, 4f);
        InvokeRepeating("Fast", 1f, 3f);

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
        BulletController2 bulletComponent = myBullet.GetComponent<BulletController2>();
        bulletComponent.direction = new Vector2(-2,-1);
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
       

        if (other.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }

    }
    void Fast()
    {
        velocity = +0.5f;
    }
    void Kill()
    {
        Destroy(gameObject);
    }

}