using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MainSceneManagement : MonoBehaviour
{
    public GameObject openingCutscene;
    public PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        openingCutscene.SetActive(true);
        director.Play();
    }

    public void OpeningCutsceneEnd()
    {

    }

    
}
