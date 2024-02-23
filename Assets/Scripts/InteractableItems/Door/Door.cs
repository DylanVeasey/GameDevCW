using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Animator m_animatior;
    private bool m_isOpen = false;
    private int m_doorOpenHash;
    private int m_doorCloseHash;


    [field: SerializeField] public bool CanInteract { get; set; }
    [field: SerializeField] public bool IsBlocked { get; set; }

    public void FailedInteract()
    {
        //RATTLE
        Debug.Log("RATTLE");
    }

    public void Interact()
    {
        ToggleDoor();
    }

    private void Start()
    {
        m_doorOpenHash = Animator.StringToHash("OpenDoor");
        m_doorCloseHash = Animator.StringToHash("CloseDoor");
    }

    public void ToggleDoor()
    {
        Debug.Log("Toggle Door");
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