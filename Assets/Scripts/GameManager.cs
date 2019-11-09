
using UnityEngine;
using System.Collections;
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
    
    public static int nLevel = 0;
  
    public Player PC;
    public static GameManager me;
    public UIManager UIManager;
    public GameState GameState = GameState.Ready;
    // Start is called before the first frame update
    public float fGametime;
    public int Die;
    public int nEnemyCnt;

public void Awake()
{
    me = this;
}

void Start()
{
    GameState = GameState.Ready;
    PC = GameObject.FindObjectOfType<Player>();
    UIManager = GameObject.FindObjectOfType<UIManager>();
    nEnemyCnt = GameObject.FindGameObjectsWithTag("Enemy").Length;
}

    void GameInit()
    {
        GameState = GameState.Ready;
        PC.fCooltime = 3f;
    }

    public void GameStart()
    {
         UIManager.GameStart();
         GameState = GameState.Play;
       
        
    }
    public void Clear()
    {
      
        nLevel++;
        SceneManager.LoadScene(nLevel);
    }
     // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            case GameState.Ready: //191029 
              Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    GameStart();
                }

                break;

            case GameState.Play:
                
                
                Time.timeScale = 1f;                
                nEnemyCnt = GameObject.FindGameObjectsWithTag("Enemy").Length;

                if(PC.nHP <= 0) // 게임 실패 조건
                    GameState = GameState.Gameover;
                if(nEnemyCnt <= 0) //게임 쿨라어 조건 달성
                {  
                    GameState = GameState.Clear;
                }
                if (fGametime < 1000)
                    fGametime += Time.deltaTime;


  
                break;

            case GameState.Pause:
        
                Time.timeScale = 0f;

                break;

            case GameState.Clear:
                Time.timeScale = 0.7f;

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
                    Clear();
                break;

            case GameState.Gameover:
                Time.timeScale = 0.05f;

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Die++;
                    SceneManager.LoadScene(0);
                    GameInit();
                }
                break;

            case GameState.FinalResult:
                Time.timeScale = 0f;
                break;
        }
        
    }
}
