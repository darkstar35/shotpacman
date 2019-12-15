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

public void OnFireButtonPressed()
{
    Debug.Log("Fired a bullet!");
}

    // Update is called once per frame
    void Update()
    {


 
    }
}
