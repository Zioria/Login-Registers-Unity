using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchRegisOrLogin : MonoBehaviour
{
    public void Register()
    {
        SceneManager.LoadScene("Register");
    }

    public void Login()
    {
        SceneManager.LoadScene("Login");
    }
}
