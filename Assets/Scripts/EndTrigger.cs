using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public AudioClip EndAudio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UIManager.Singleton.ShowEnd();
            AudioManager.Singleton.PlayAVoice(EndAudio);
        }
    }
}
