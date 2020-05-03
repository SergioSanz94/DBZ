using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject player;
  
     // Start is called before the first frame update
   public void PlayerJump()
    {
        player.SendMessage("UpdateState","GohanSalto");
        player.SendMessage("UpdateAttack", "true");
    }
    public void PlayerShoot()
    {
        player.SendMessage("UpdateState", "PlayerAttack");
        player.SendMessage("UpdateAttack", "true");
    }
}
