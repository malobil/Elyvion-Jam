using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string GameScene;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        if(GetComponent<ExampleError>().CheckErrors())
        {
            SceneManager.LoadScene(GameScene);
        }
        else
        {
            UIManager.Singleton.ShowErrorText(GetComponent<ExampleError>().LastError);
        }
    }
}
