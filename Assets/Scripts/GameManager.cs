
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SceneManagement;



public enum GameState
{
    Ready,
    Play,
    Pause,
    Clear,
    Gameover,
    FinalResult,
    AskEnd,
    DieDeley

}

public class GameManager :  Singleton<GameManager>
{

    public static GameManager me;
    public GameState GameState = GameState.Ready;
    // Start is called before the first frame update
    public float fGametime;
    public int Die;
    public Player PC;

public void Awake()
{

    me = this;
}

    void Start()
    {
        GameState = GameState.Ready;
    }

      void GameInit()
    {
        GameState = GameState.Ready;
        PC.fCooltime = 3f;
    }

    public void GameStart()
    {
        GameState = GameState.Play;
        
    }
    void Clear()
    {
        GameState = GameState.Ready;
    }
    // Update is called once per frame
    void Update()
    {

        switch (GameState)
        {
            case GameState.Ready: //191029 
              Time.timeScale = 0f;

                break;

            case GameState.Play:
            Time.timeScale = 1f;
                if (fGametime < 1000)
                    fGametime += Time.deltaTime;

  
                break;

            case GameState.Pause:
        
                Time.timeScale = 0f;

                break;

            case GameState.Clear:
                Time.timeScale = 0.7f;

                if (Input.GetKeyDown(KeyCode.Space))
                    Clear();
                break;

            case GameState.Gameover:
                Time.timeScale = 0.05f;
;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Die++;
                    GameInit();
                }
                break;

            case GameState.FinalResult:
                Time.timeScale = 0f;
                break;
        }
        
    }
}
