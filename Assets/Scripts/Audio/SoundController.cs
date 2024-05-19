using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private GameObject player;
    private AudioSource audioSource;
    private Vector3 objectPosition;
    private Vector3 directionToPlayer;
    private bool isPlaying = false;
    public float range;

    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        audioSource = this.GetComponent<AudioSource>();
        objectPosition = this.transform.position;
        layerMask = LayerMask.NameToLayer("Structure");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        directionToPlayer = player.transform.position - this.transform.position;
        RaycastHit _hit;
        if (Vector3.Distance(objectPosition, player.transform.position) <= range)
        {
            Debug.DrawRay(objectPosition, directionToPlayer, Color.green);
            if (Physics.Raycast(objectPosition, directionToPlayer, out _hit, layerMask))
            {
                Debug.Log(_hit.transform.gameObject.layer);
                if (_hit.transform.CompareTag("Player") || _hit.transform.CompareTag("AudioSource"))
                {
                    if (!isPlaying)
                    {
                        audioSource.time = Random.Range(0f, audioSource.clip.length);
                        audioSource.Play();
                        isPlaying = true;
                    }
                }
                else
                {
                    if (isPlaying)
                    {
                        //Stop our audio
                        audioSource.Stop();
                        isPlaying = false;
                    }
                }
            }
        }
        else
        {
            if (isPlaying)
            {
                //Stop our audio
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
