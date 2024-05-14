using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    //Animation variables
    public Animator m_animatior;
    private int m_doorOpenHash;
    private int m_doorCloseHash;
    private int m_doorRattleHash;

    //Audio variables
    public AudioSource audioSource;
    public AudioClip openSoundClip;
    public AudioClip rattleSoundClip;

    //Door Status variable
    public bool b_isOpen = false;

    // Interactable interface variables
    [field: SerializeField] public bool b_canInteract { get; set; }
    [field: SerializeField] public bool b_isBlocked { get; set; }

    public void FailedInteract()
    {
        //Check if we contain the KeyLock Component
        if (TryGetComponent<KeyLock>(out KeyLock foundKeyLock) & b_isBlocked)
        {
            foundKeyLock.TryUnlock();
        }
        else
        {
            //RATTLE
            Rattle();
        } 
    }

    public void Rattle()
    {
        if (rattleSoundClip != null)
        {
            audioSource.PlayOneShot(rattleSoundClip, 1);
        }
        m_animatior.Play(m_doorRattleHash);
    }

    
    virtual public void Interact()
    {
       ToggleDoor();
    }

    private void Start()
    {
        m_doorOpenHash = Animator.StringToHash("OpenDoor");
        m_doorCloseHash = Animator.StringToHash("CloseDoor");
        m_doorRattleHash = Animator.StringToHash("DoorRattle");
    }

    public void ToggleDoor()
    {
        if (openSoundClip != null)
        {
            audioSource.PlayOneShot(openSoundClip, 1);
        }
        
        if (b_isOpen)
            CloseDoor();
        else
            OpenDoor();
    }

    public void CloseDoor()
    {
        m_animatior.Play(m_doorCloseHash);
        b_isOpen = false;
    }

    public void OpenDoor()
    {
        m_animatior.Play(m_doorOpenHash);
        b_isOpen = true;
    }

    public void ResetDoor()
    {
        if (b_isOpen)
        {
            m_animatior.Play(m_doorCloseHash);
        }
        b_isOpen = false;
    }
}