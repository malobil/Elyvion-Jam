using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LevierMusique : InteractableObject
{
    public List<AudioSource> SteleAudioComp;
    public List<GameObject> SteleLight;
    public List<string> FilesNames;
    public List<SteleSound> ContentAndSound;

    private string ErrorFolderPath;

    private List<AudioClip> SoundsToPlay = new List<AudioClip>();
    private Animator AnimComp;
    private bool IsUsed = false;

    public override void OnEnter()
    {
        ErrorFolderPath = Directory.GetParent(Application.dataPath) + "/ERRORS/";
        AnimComp = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();

        if(!IsUsed)
        {
            StopCoroutine(WaitSoundToEnd());
            SoundsToPlay.Clear();
            for (int i = 0; i < FilesNames.Count; i++)
            {
                if (File.Exists(ErrorFolderPath + FilesNames[i]))
                {
                    for (int y = 0; y < ContentAndSound.Count; y++)
                    {
                        if (File.ReadAllText(ErrorFolderPath + FilesNames[i]) == ContentAndSound[y].FileContent)
                        {
                            SoundsToPlay.Add(ContentAndSound[y].AssociateSound);
                        }
                    }
                }
                else
                {
                    SoundsToPlay.Add(null);
                }
            }

            AnimComp.SetTrigger("Use");
            StartCoroutine(WaitSoundToEnd());
            IsUsed = true;
        }
        
    }

    IEnumerator WaitSoundToEnd()
    {
        for(int i = 0; i < SoundsToPlay.Count; i++)
        {
            SteleAudioComp[i].PlayOneShot(SoundsToPlay[i]);
            SteleLight[i].SetActive(true);
            Debug.Log(SoundsToPlay[i]);
            yield return new WaitWhile(() => SteleAudioComp[i].isPlaying);
            SteleLight[i].SetActive(false);
        }

        IsUsed = false;
       
    }
}

[Serializable]
public class SteleSound
{
    public string FileContent ;
    public AudioClip AssociateSound;
}
