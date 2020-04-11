using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : FileChecker
{
    [SerializeField] private GameObject FireEffect;

    public override void FileCreatedDetected()
    {
        base.FileCreatedDetected();
        FireEffect.SetActive(true);
    }

    public override void FileRemoved()
    {
        base.FileRemoved();
        FireEffect.SetActive(false);
    }
}
