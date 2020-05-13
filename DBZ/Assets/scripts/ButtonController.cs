using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject player;
//audio
    public AudioClip shoot;
    public AudioClip jump;

    AudioSource AudioPlayer;

     void Start()
    {
    AudioPlayer = GetComponent<AudioSource>();
    }
  
    public void PlayerJump()
    {
        player.SendMessage("UpdateState","GohanSalto");

        AudioPlayer.clip = jump;
        AudioPlayer.Play();
       
    }
    public void PlayerShoot()
    {
       
            player.SendMessage("UpdateState", "PlayerAttack");
            player.SendMessage("UpdateAttack", "true");
  
            AudioPlayer.clip = shoot;
            AudioPlayer.Play();
    }
}
