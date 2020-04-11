using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class FileChecker : MonoBehaviour
{
    public string FileName;
    public string FileContent;

    private string ErrorFolderPath;
    private bool FileExist = false;

    public virtual void OnEnter()
    {
        ErrorFolderPath = Directory.GetParent(Application.dataPath) + "/ERRORS/";
    }

    public virtual void OnUpdate()
    {
        CheckFileExist();
    }


    public virtual void FileCreatedDetected()
    {
        Debug.Log("change");
        FileExist = true;
    }

    public virtual void FileRemoved()
    {
        Debug.Log("change");
        FileExist = false;
    }

    void CheckFileExist()
    {
        if(FileExist)
        {
            if (!File.Exists(ErrorFolderPath + FileName))
            {
                FileRemoved();
            }
        }
        else
        {
            if (File.Exists(ErrorFolderPath + FileName))
            {
                FileCreatedDetected();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        OnEnter();   
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
}
