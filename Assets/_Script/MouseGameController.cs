using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGameController : MonoBehaviour, IGameController
{

   public Action<int, string> FireButtonPressed;

   void Update()
   {
       if(Input.GetMouseButtonDown(0))
       {
           //if(FireButtonPressed != null)
           //FireButtonPressed();
       }

   }
   public void OnFireButtonPressed()
   {
       Debug.Log("Fired a bullet");

   }

   public void OnFireButtonPressed(int count)
   {

   }

}
