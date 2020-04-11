using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExampleError : MonoBehaviour
{
    public List<ErrorClass> ErrorsToCorrect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool CheckFileContent(ErrorClass ErrorToCheck)
    {
        if (File.Exists(Application.dataPath + "/ERRORS/" + ErrorToCheck.FileName))
        {
            if (File.ReadAllText(Application.dataPath + "/ERRORS/" + ErrorToCheck.FileName) == ErrorToCheck.FileContent)
            {
                return true;
            }
        }
        return false;
    }

    bool CheckFileExist(ErrorClass ErrorToCheck)
    {
        if (File.Exists(Application.dataPath + "/ERRORS/" + ErrorToCheck.FileName))
        {
            return true;
        }
        return false;
    }

    bool CheckFileDoNotExist(ErrorClass ErrorToCheck)
    {
        if (File.Exists(Application.dataPath + "/ERRORS/" + ErrorToCheck.FileName))
        {
            return false;
        }
        return true;
    }

    bool CheckFolderExist(ErrorClass ErrorToCheck)
    {
        if (Directory.Exists(Application.dataPath + "/ERRORS/" + ErrorToCheck.FileName))
        {
           return true;
        }
        return false;
    }

    bool CheckFolderDoNotExist(ErrorClass ErrorToCheck)
    {
        if (Directory.Exists(Application.dataPath + "/ERRORS/" + ErrorToCheck.FileName))
        {
            return false;
        }
        return true;
    }

    bool CheckFileExtension(ErrorClass ErrorToCheck)
    {
        if (Directory.Exists(Application.dataPath + "/ERRORS/" + ErrorToCheck.FileName))
        {
            DirectoryInfo infos = new DirectoryInfo(Application.dataPath + "/ERRORS/" + ErrorToCheck.FileName);
            FileInfo[] files = infos.GetFiles();

            foreach(FileInfo f in files)
            {
                if(f.Extension == ErrorToCheck.FileExtension)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckErrors()
    {
        foreach(ErrorClass errors in ErrorsToCorrect)
        {
            switch(errors.Error)
            {
                case ErrorType.FileContent:
                    if (CheckFileContent(errors)) continue;
                    else return false;

                case ErrorType.FolderDontExist:
                    if (CheckFolderDoNotExist(errors)) continue;
                    else return false;

                case ErrorType.FolderExist:
                    if (CheckFolderExist(errors)) continue;
                    else return false;

                case ErrorType.FileExist:
                    if (CheckFileExist(errors)) continue;
                    else return false;

                case ErrorType.FileDontExist:
                    if (CheckFileDoNotExist(errors)) continue;
                    else return false;

                case ErrorType.FileExtension:
                    if (CheckFileExtension(errors)) continue;
                    else return false;

            }
        }

        return true;
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
