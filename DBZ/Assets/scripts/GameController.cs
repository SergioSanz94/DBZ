using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float ParallaxSpeed = 0.02f;
    public RawImage Background;
    public RawImage platform;
    public GameObject uiIdle;
    public GameObject uiGOver;
    public GameObject player;
    public GameObject game;
    public enum GameState { Idle, Playing, GameOver};
    public GameState gameState = GameState.Idle;
    public GameObject EnemyGenertor2;
    public GameObject EnemyGenertor;


    public AudioClip fondo;
    public AudioClip die;

    AudioSource musicPlayer;



    // Start is called before the first frame update
    void Start()
    {
        uiGOver.SetActive(false);

       musicPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //Empieza el juego
        if (gameState == GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
            player.SendMessage("UpdateState", "PlayerRun");
            EnemyGenertor.SendMessage("StartGenerator1");
            EnemyGenertor2.SendMessage("StartGenerator1");
            game.gameObject.GetComponent<Canvas>().sortingOrder = 0;
           
            musicPlayer.clip = fondo;
            musicPlayer.Play();

        }
        else if(gameState == GameState.Playing) //Juego en marcha
        {
            Parallax();
        }
        else if (uiGOver.active == true)
        {
            gameState = GameState.GameOver;
            musicPlayer.Stop();
            musicPlayer.clip = die;
            musicPlayer.Play();
        }
        
    }
    void Parallax()
    {
        float finalSpeed = ParallaxSpeed * Time.deltaTime;
        Background.uvRect = new Rect(Background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
    }
   
}
