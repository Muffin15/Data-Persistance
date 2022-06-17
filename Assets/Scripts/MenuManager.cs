using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
