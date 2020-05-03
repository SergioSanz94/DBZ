using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private playerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<playerController>();
    }

    public void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Plataforma")
        {
            player.grounded = true;
        }
      
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Plataforma")
        {
            player.grounded = false;
        }
       
    }
}
