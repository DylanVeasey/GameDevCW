using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardStateController : MonoBehaviour
{
    public IGuardState currentState;

    public GuardIdleState idleState = new GuardIdleState();
    public GuardPatrollingState patrollingState = new GuardPatrollingState();
    public GuardChasingState chasingState = new GuardChasingState();

    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;

    [field: SerializeField] public Transform[] Waypoints;

    [field: SerializeField] public GuardTrigger entryTrigger;

    void Start()
    {
        player = GameObject.Find("Player");
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
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
}
