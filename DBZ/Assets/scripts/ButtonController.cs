using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject player;
  
    public void PlayerJump()
    {
        player.SendMessage("UpdateState","GohanSalto");
       
    }
    public void PlayerShoot()
    {
       
            player.SendMessage("UpdateState", "PlayerAttack");
            player.SendMessage("UpdateAttack", "true");
  
    }
}
