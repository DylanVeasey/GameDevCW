using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchUnlightEvent : MonoBehaviour
{
    private GameObject TorchLight;
    private SoundController soundController;
    private AudioSource audioSource;

    private void Start()
    {
        soundController = this.GetComponent<SoundController>();
        audioSource = this.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        WindowEvent.onWindowUnlightTorch += updateTorch;
    }

    private void updateTorch()
    {
        soundController.enabled = false;
        audioSource.Stop();
        //Update the Model of the torch
        TorchLight = this.transform.GetChild(0).gameObject;
        Destroy(TorchLight);
    }
}
