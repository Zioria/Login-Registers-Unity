using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;



public class AccountRegisterLogin : MonoBehaviour
{
    public string baseUrl = "http://localhost/Ziori/UnityRegisterAndLogin/";
    
    public InputField accountUsername;
    public InputField accountPassword;
    [SerializeField] private Text Info;

    [SerializeField] private string cur_Name;
    [SerializeField] private string ukey = "accountusername";
    
    // Start is called before the first frame update

   

    void Start()
    {
        cur_Name = "";

        if (PlayerPrefs.HasKey(ukey))
        {
            if (PlayerPrefs.GetString(ukey) != "")
            {
                cur_Name = PlayerPrefs.GetString(ukey);
                Info.text = "Welcome :" + cur_Name;
            }
            else
            {
                Info.text = "You are not Login.";

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AccountRegister()
    {
        string uName = accountUsername.text;
        string pWord = accountPassword.text;
        StartCoroutine(RegisterNewAccount(uName, pWord));
    }
    
    public void AccountLogin()
    {
        string uName = accountUsername.text;
        string pWord = accountPassword.text;
        StartCoroutine(LoginAccount(uName, pWord));
    }

    public void AccountLogout()
    {
        cur_Name = "";
        PlayerPrefs.SetString(ukey, cur_Name);
        Info.text = "Log out !!";
    }

    IEnumerator RegisterNewAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("newAccountUsername", uName);
        form.AddField("newAccountPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("www.error");
            }
            else
            {
                string reponseText = www.downloadHandler.text;
                Debug.Log("Reponse Text from the sever = " + reponseText);
                Info.text =  reponseText;
            }
        }
    }
    
    IEnumerator LoginAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", uName);
        form.AddField("loginPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("www.error");
            }
            else
            {
                string reponseText = www.downloadHandler.text;
                if (reponseText == "1")
                {
                    PlayerPrefs.SetString(ukey, uName);
                    Info.text = "Login Success " + uName;
                    SceneManager.LoadScene("Info player");
                }
                else
                {
                    Info.text =  "Login Failed.";
                }
               
                
            }
        }
    }
}
