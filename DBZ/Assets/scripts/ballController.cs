using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        transform.Translate(movement);


    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        
        if (other.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
        }
        
    }
    
}
