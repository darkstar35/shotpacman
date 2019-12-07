using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    IGameController controller;

    // Start is called before the first frame update
public BulletLauncher(IGameController controller)
{
    this.controller = controller;
}


public void SetGameController(IGameController controller)
{
    this.controller = controller;

}

    // Update is called once per frame
    void Update()
    {
        if(controller != null)
        {
            if(controller.FireButtonPressed())
            Debug.Log("Fired a Bullet!");
        }
        else
        {

            Debug.LogError("controlleris null!");
        }

 
    }
}
