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
        {bullets[n].SetNativeSize();
        bullets[n].color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int n = 0; n < player.bulletInven.Count; n++)
        bullets[n].SetNativeSize(); 


        hp.text = player.nHP.ToString(); 
    }
}
