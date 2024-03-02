using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;
    public Transform[] Waypoints;
    private bool B_moving = false;
    private int i = 0;
    private LayerMask _layerMask;

    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        MoveToWayPoints();
    }

    void Update()
    {
        CheckWaypoint();
    }

    void FixedUpdate()
    {
        //Check Distance Between this object and the Player
        float distance = Vector3.Distance(agent.transform.position, player.transform.position);


        _layerMask = 1 << 0;

        RaycastHit hit;
        if(Physics.Raycast(agent.transform.position, -(agent.transform.position - player.transform.position), out hit, Mathf.Infinity, _layerMask))
        {
            Debug.DrawRay(agent.transform.position, -(agent.transform.position - player.transform.position), Color.blue);
            Debug.Log("TRUE");
        }
        else
        {
            Debug.DrawRay(agent.transform.position, -(agent.transform.position - player.transform.position), Color.red);
            Debug.Log("FALSE");
        }

    }

    void MoveToWayPoints()
    {
        agent.destination = Waypoints[i].position;
    }

    void CheckWaypoint()
    {
        if (Vector3.Distance(agent.transform.position, Waypoints[i].position) < 1f)
        {
            Debug.Log("Test");
            Debug.Log(Waypoints.Length);
            Debug.Log(i);
            if(i + 1 < Waypoints.Length)
            {
                Debug.Log("NOt Reached end of list");
                i++;
            }
            else
            {
                Debug.Log("Reached end of list");
                i = 0;
            }
            agent.destination = Waypoints[i].position;

        }
    }
}

    
