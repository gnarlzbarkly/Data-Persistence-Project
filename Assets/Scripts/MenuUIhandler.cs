using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIhandler : MonoBehaviour
{
    public string Name;
    // Start is called before the first frame update

    void Start()
    {
        Name = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartNew()
    {
        if(!string.IsNullOrEmpty(this.Name))
        {
            MenuManager.Instance.Name = this.Name;
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Name is empty.");
        }
    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor(); 
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void UpdateName(InputField input)
    {
        this.Name = input.text;
        Debug.Log(this.Name);
    }
}
