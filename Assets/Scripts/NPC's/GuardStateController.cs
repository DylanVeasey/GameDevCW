using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardStateController : MonoBehaviour
{
    public IGuardState currentState;

    public GuardIdleState idleState = new GuardIdleState();
    public GuardPatrollingState patrollingState = new GuardPatrollingState();
    public GuardChasingState chasingState = new GuardChasingState();
    public GuardAttackState attackState = new GuardAttackState();

    public UnityEngine.AI.NavMeshAgent agent;

    public Animator m_animator;
    public int m_guardWalkHash;
    public int m_guardRunHash;
    public int m_guardIdleHash;

    public int m_guardAttack1Hash;
    public int m_guardAttack2Hash;
    public int m_guardAttack3Hash;
    public int m_guardAttack4Hash;
    public int m_guardAttack5Hash;
    public int m_guardAttack6Hash;

    public int[] guardAttackHashes;

    private int randomAttackState;
    private int randomDamage;

    public GameObject player;
    private PlayerController playerController;

    [field: SerializeField] public Transform[] Waypoints;

    [field: SerializeField] public GuardTrigger entryTrigger;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();

        m_guardWalkHash = Animator.StringToHash("walk");
        m_guardRunHash = Animator.StringToHash("run");
        m_guardIdleHash = Animator.StringToHash("Unarmed-Idle-Static");

        m_guardAttack1Hash = Animator.StringToHash("Unarmed-Attack-L1");
        m_guardAttack2Hash = Animator.StringToHash("Unarmed-Attack-L2");
        m_guardAttack3Hash = Animator.StringToHash("Unarmed-Attack-L3");
        m_guardAttack4Hash = Animator.StringToHash("Unarmed-Attack-R1");
        m_guardAttack5Hash = Animator.StringToHash("Unarmed-Attack-R2");
        m_guardAttack6Hash = Animator.StringToHash("Unarmed-Attack-R3");

        guardAttackHashes = new int[6] { m_guardAttack1Hash, m_guardAttack2Hash, m_guardAttack3Hash, m_guardAttack4Hash, m_guardAttack5Hash, m_guardAttack6Hash};

        randomAttackState = Random.Range(0, 5);
        randomDamage = Random.Range(10, 20);

        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this); 
    }

    public void ChangeState(IGuardState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        Debug.Log(currentState);
        currentState.OnEnter(this);
    }

    public void startCoroutine()
    {
        StartCoroutine(attackCooldown());
    }

    private IEnumerator attackCooldown()
    {
        m_animator.Play(guardAttackHashes[randomAttackState]);
        playerController.dealDamage(randomDamage);

        yield return new WaitForSeconds(1.5f);
        randomAttackState = Random.Range(0, 5);
        randomDamage = Random.Range(10, 20);

        Debug.Log("DEAL DAMAGE");
        attackState.isOnCooldown = false;

        if (Vector3.Distance(this.agent.transform.position, player.transform.position) > 2.0f)
        {
            Debug.Log("BACK TO CHASING");
            this.ChangeState(this.chasingState);
        }    
        yield return null;

    }
}
