using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchRegisOrLogin : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("Register");
    }

    public void Register()
    {
        SceneManager.LoadScene("Register");
    }

    public void Login()
    {
        SceneManager.LoadScene("Login");
    }
    
    public void LoginSuccess()
    {
        SceneManager.LoadScene("Info player");
    }
}
