using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGameController : IGameController
{

public bool FireButtonPressed()
{
 Debug.Log("Fired bullet");
 return Input.GetKeyDown(KeyCode.Space);
}

}
