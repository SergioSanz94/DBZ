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
    public GameObject life;
    public GameObject buttom;
    public GameObject destroyer2;
    public enum GameState { Idle, Playing, GameOver};
    public GameState gameState = GameState.Idle;
    public GameObject EnemyGenertor2;
    public GameObject EnemyGenertor;

    // Start is called before the first frame update
    void Start()
    {
        uiGOver.SetActive(false);
        life.SetActive(false);
        buttom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //Empieza el juego
        if (gameState == GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
            player.SetActive(true);
            life.SetActive(true);
            buttom.SetActive(true);
            player.SendMessage("UpdateState", "PlayerRun");
            EnemyGenertor.SendMessage("StartGenerator1");
            EnemyGenertor2.SendMessage("StartGenerator2");
          
           
        }
        else if(gameState == GameState.Playing) //Juego en marcha
        {
            Parallax();
        }
         else if(gameState == GameState.GameOver) 
        {
            destroyer2.SetActive(true);
            player.SetActive(false);
            life.SetActive(false);
            buttom.SetActive(false);
            EnemyGenertor.SendMessage("CancelGenerator1");
            EnemyGenertor2.SendMessage("CancelGenerator2");
           

        }
        if(gameState == GameState.GameOver && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            destroyer2.SetActive(false);
            uiGOver.SetActive(false);
            player.SetActive(true);
            life.SetActive(true);
            buttom.SetActive(true);
            player.SendMessage("UpdateState", "PlayerRun");
            EnemyGenertor.SendMessage("StartGenerator1");
            EnemyGenertor2.SendMessage("StartGenerator2");
        }

    }
    void Parallax()
    {
        float finalSpeed = ParallaxSpeed * Time.deltaTime;
        Background.uvRect = new Rect(Background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
    }
    public void UpdateGame(string state = null)
    {
        if (state != null)
        {
            gameState = GameState.GameOver;

        }
    }
   
}
