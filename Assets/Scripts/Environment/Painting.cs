using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Painting : FileChecker
{
    public RawImage ImageComp;

    public override void FileCreatedDetected()
    {
        base.FileCreatedDetected();

        if (File.Exists(ErrorFolderPath + FileName))
        {
            WWW www = new WWW("file://" + ErrorFolderPath + FileName);
            Texture2D tmpText = new Texture2D(1080, 1080);
            www.LoadImageIntoTexture(tmpText);
            ImageComp.texture = tmpText;
            ImageComp.gameObject.SetActive(true);
        }
    }

    public override void FileRemoved()
    {
        base.FileRemoved();
        ImageComp.gameObject.SetActive(false);
    }
}
