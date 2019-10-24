using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Player player;
    public Image[] bullets;
    public Text hp;
    public GameState GameState;
    public Image gamestart;
    public Image gameover;
    public Image gamemenuimg;
    
    // Start is called before the first frame update
    void Start()
    {
        gameover.gameObject.SetActive(false);
    


        for(int n = 0; n < bullets.Length; n++)
        {
        bullets[n].SetNativeSize();
        bullets[n].color = Color.blue;
        }
    }
    public void GameStart()
    {
       gamestart.gameObject.SetActive(false);
       gamemenuimg.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        switch(GameState)
        {
            case GameState.Ready: 
              Time.timeScale = 0f;
gameover.gameObject.SetActive(false);

                break;

            case GameState.Play:
         

  
                break;

            case GameState.Pause:
        
            
                break;

            case GameState.Clear:
      
                break;

            case GameState.Gameover:
                
                break;

            case GameState.FinalResult:
             
                break;
        }


        



        for(int n = 0; n < bullets.Length; n++)
        bullets[n].gameObject.SetActive(false); 

  
        for(int n2 = 0; n2 < player.nbulletcnt; n2++)
        bullets[n2].gameObject.SetActive(true); 

        hp.text = player.nHP.ToString(); 
    }
}
