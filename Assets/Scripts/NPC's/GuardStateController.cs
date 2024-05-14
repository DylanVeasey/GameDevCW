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

    public Animator m_animatior;
    public int m_guardWalkHash;
    public int m_guardRunHash;

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
        playerController.dealDamage(10);

        yield return new WaitForSeconds(3);

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
