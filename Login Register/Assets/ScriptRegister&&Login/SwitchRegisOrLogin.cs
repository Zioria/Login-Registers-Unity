using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchRegisOrLogin : MonoBehaviour
{
   [SerializeField] private GameObject LoginParent;
   [SerializeField] private GameObject RegisterParent;
   
   

   public void Login()
   {
      SceneManager.LoadScene("Info player");
   }

   public void Logout()
   {
      SceneManager.LoadScene("Register&Login");
   }
}
