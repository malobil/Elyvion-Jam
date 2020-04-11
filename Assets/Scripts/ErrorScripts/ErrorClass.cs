using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ErrorType {FileContent, FileExist, FileDontExist, FolderExist, FolderDontExist, FileExtension}

[Serializable]
public class ErrorClass
{
    public ErrorType Error;

    public string FileName;

    public string FileContent ;
    public string FileExtension ;
}
