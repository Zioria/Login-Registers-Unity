using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class AccountRegisterLogin : MonoBehaviour
{
    public string baseUrl = "http://localhost/Ziori/UnityRegisterAndLogin/";
    
    public InputField accountUsername;
    public InputField accountPassword;
    public Text Info;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
                Debug.Log("Reponse Text from the sever = " + reponseText);
                Info.text =  reponseText;
            }
        }
    }
}
