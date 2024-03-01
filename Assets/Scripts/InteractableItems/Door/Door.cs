using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Animator m_animatior;
    protected bool m_isOpen = false;
    private int m_doorOpenHash;
    private int m_doorCloseHash;
    private int m_doorRattleHash;

    public AudioSource audioSource;
    public AudioClip openSoundClip;
    public AudioClip rattleSoundClip; 




    [field: SerializeField] public bool CanInteract { get; set; }
    [field: SerializeField] public bool IsBlocked { get; set; }

    public void FailedInteract()
    {
        //RATTLE
        if(rattleSoundClip != null)
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
        
        if (m_isOpen)
            CloseDoor();
        else
            OpenDoor();
    }

    public void CloseDoor()
    {
        m_animatior.Play(m_doorCloseHash);
        m_isOpen = false;
    }

    public void OpenDoor()
    {
        m_animatior.Play(m_doorOpenHash);
        m_isOpen = true;
    }

    public void ResetDoor()
    {
        if (m_isOpen)
        {
            m_animatior.Play(m_doorCloseHash);
        }
        m_isOpen = false;
    }
}