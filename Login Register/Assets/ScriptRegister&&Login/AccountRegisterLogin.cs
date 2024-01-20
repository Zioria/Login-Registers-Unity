using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class AccountRegisterLogin : MonoBehaviour
{
    public InputField accountUsername;
    public InputField accountPassword;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AccountReister()
    {
        string uName = accountUsername.text;
        string pWord = accountPassword.text;
        StartCoroutine(RegisterNewAccount(uName, pWord));
    }

    IEnumerator RegisterNewAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", uName);
        form.AddField("password", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/tutorial/unityphppostget/", form))
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
            }
        }
    }
}
