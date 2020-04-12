using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExampleError : MonoBehaviour
{
    public List<ErrorClass> ErrorsToCorrect;
    public AudioClip IndicationSound;

    private bool HadPlayIndicationSound = false;
    private string ErrorFolderPath;

    public string LastError { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        ErrorFolderPath = Directory.GetParent(Application.dataPath) + "/ERRORS/";
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool CheckFileContent(ErrorClass ErrorToCheck)
    {
        if (File.Exists(ErrorFolderPath + ErrorToCheck.FileName))
        {
            if (File.ReadAllText(ErrorFolderPath + ErrorToCheck.FileName) == ErrorToCheck.FileContent)
            {
                return true;
            }
        }
        return false;
    }

    bool CheckFileExist(ErrorClass ErrorToCheck)
    {
        if (File.Exists(ErrorFolderPath + ErrorToCheck.FileName))
        {
            return true;
        }
        return false;
    }

    bool CheckFileDoNotExist(ErrorClass ErrorToCheck)
    {
        if (File.Exists(ErrorFolderPath + ErrorToCheck.FileName))
        {
            return false;
        }
        return true;
    }

    bool CheckFolderExist(ErrorClass ErrorToCheck)
    {
        if (Directory.Exists(ErrorFolderPath + ErrorToCheck.FileName))
        {
           return true;
        }
        return false;
    }

    bool CheckFolderDoNotExist(ErrorClass ErrorToCheck)
    {
        if (Directory.Exists(ErrorFolderPath + ErrorToCheck.FileName))
        {
            return false;
        }
        return true;
    }

    bool CheckFileExtension(ErrorClass ErrorToCheck)
    {
        if (Directory.Exists(ErrorFolderPath + ErrorToCheck.FileName))
        {
            DirectoryInfo infos = new DirectoryInfo(ErrorFolderPath + ErrorToCheck.FileName);
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
                    if (CheckFileContent(errors))
                    {
                        continue;
                    }
                    else
                    {
                        LastError = errors.ErrorName;
                        PlayIndicationSound();
                        return false;
                    }

                case ErrorType.FolderDontExist:
                    if (CheckFolderDoNotExist(errors)) continue;
                    else
                    {
                        LastError = errors.ErrorName;
                        PlayIndicationSound();
                        return false;
                    }

                case ErrorType.FolderExist:
                    if (CheckFolderExist(errors)) continue;
                    else
                    {
                        LastError = errors.ErrorName;
                        PlayIndicationSound();
                        return false;
                    }

                case ErrorType.FileExist:
                    if (CheckFileExist(errors)) continue;
                    else
                    {
                        LastError = errors.ErrorName;
                        PlayIndicationSound();
                        return false;
                    }

                case ErrorType.FileDontExist:
                    if (CheckFileDoNotExist(errors)) continue;
                    else
                    {
                        LastError = errors.ErrorName;
                        PlayIndicationSound();
                        return false;
                    }

                case ErrorType.FileExtension:
                    if (CheckFileExtension(errors)) continue;
                    else
                    {
                        LastError = errors.ErrorName;
                        PlayIndicationSound();
                        return false;
                    }

            }
        }

        return true;
    }

    void PlayIndicationSound()
    {
        if (!HadPlayIndicationSound && IndicationSound != null)
        {
            AudioManager.Singleton.PlayAVoice(IndicationSound);
            HadPlayIndicationSound = true;
        }

    }
}
