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

    public enum GameState { Idle, Playing, GameOver};
    public GameState gameState = GameState.Idle;

    public GameObject EnemyGenertor;
    // Start is called before the first frame update
    void Start()
    {
        uiGOver.SetActive(false);
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
           // EnemyGenertor.SendMessage("StartGenerator1");
        }
        else if(gameState == GameState.Playing) //Juego en marcha
        {
            Parallax();
        }
        else if (uiGOver.active == true)
        {
            gameState = GameState.GameOver;
        }
        
    }
    void Parallax()
    {
        float finalSpeed = ParallaxSpeed * Time.deltaTime;
        Background.uvRect = new Rect(Background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
    }
}
