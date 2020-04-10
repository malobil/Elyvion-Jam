using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExampleError : MonoBehaviour,IInteractable
{
    public ErrorClass ErrorsToCorrect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            CheckFileContent();
        }
    }

    bool CheckFileContent()
    {
        if (File.Exists(Application.dataPath + "/ERRORS/" + ErrorsToCorrect.FileName))
        {
            if (File.ReadAllText(Application.dataPath + "/ERRORS/" + ErrorsToCorrect.FileName) == ErrorsToCorrect.FileContent)
            {
                return true;
            }
        }
        Debug.Log(Application.dataPath + "/ERRORS/" + ErrorsToCorrect.FileName);

        return false;
    }

    public virtual void Interact()
    {
        if(CheckFileContent())
        {
            Resolved();
        }
        else
        {
            NotResolved();
        }
    }

    public virtual void Resolved()
    {
        Debug.Log("RESOLV");
    }

    public virtual void NotResolved()
    {
        Debug.Log("ERROR");
    }
}
