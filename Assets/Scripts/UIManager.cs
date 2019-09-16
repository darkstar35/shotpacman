using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Player player;
    public Image[] bullets;
    public Text hp;
    // Start is called before the first frame update
    void Start()
    {
        for(int n = 0; n < bullets.Length; n++)
        {
        bullets[n].SetNativeSize();
        bullets[n].color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {


        for(int n = 0; n < bullets.Length; n++)
        bullets[n].gameObject.SetActive(false); 

  
        for(int n2 = 0; n2 < player.nbulletcnt; n2++)
        bullets[n2].gameObject.SetActive(true); 

        hp.text = player.nHP.ToString(); 
    }
}
