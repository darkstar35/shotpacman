using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int MAXCNT = 8;
    public Player player;
    public Image[] bullets;
    public Text nHp;
    public Text nBulletcnt;
    public Text nStage;
    public GameState GameState;
    public Image gamestart;
    public Image gameover;
    public Image stageclear;
    public Image gamemenuimg;
    
    // Start is called before the first frame update
    void Start()
    {
        gameover.gameObject.SetActive(false);
        stageclear.gameObject.SetActive(false);
        for(int n = 0; n < bullets.Length; n++)
        {
        bullets[n].SetNativeSize();
        bullets[n].color = Color.green;
        }
    }
    public void GameStart()
    {
       gamestart.gameObject.SetActive(false);
       gamemenuimg.gameObject.SetActive(false);
       
    }

    public Text UIcntdown;
    // Update is called once per frame
    void Update()
    {

   
        nStage.text = EditorSceneManager.sceneCount.ToString();
        switch(GameManager.me.GameState)
        {
            case GameState.Ready: 
              Time.timeScale = 0f;
                gameover.gameObject.SetActive(false);

                break;

            case GameState.Play:
        
             if(player.nbulletcnt < MAXCNT)
        {
            for(int n = 0; n < bullets.Length; n++)
            bullets[n].gameObject.SetActive(false); 

            for(int n2 = 0; n2 < player.nbulletcnt; n2++)
            bullets[n2].gameObject.SetActive(true); 
        }
        nHp.text = player.nHP.ToString(); 
        nBulletcnt.text = player.nbulletcnt.ToString();

        if(player.PlayerMode == Mode.ABSORB)
          UIcntdown.text = player.fCooltime.ToString();



                break;

            case GameState.Pause:
        
            
                break;

            case GameState.Clear:
      
                break;

            case GameState.Gameover:
                Time.timeScale = 0.5f;
                gameover.gameObject.SetActive(true);
                break;

           
        }


     
    }
}
