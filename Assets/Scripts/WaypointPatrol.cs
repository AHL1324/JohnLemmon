using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    //NavMesh para poder navegar-moverse
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        //Camine el fantasma hacia X destino (el primero)
    }

    // Update is called once per frame
    void Update()
    {
        //Estamos cerca de un punto CAMBIAR, cambiar punto actual
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            //.Length se reinicia la lista. Si va al punto A, aumenta en 1, si va al punto B, se añade 1, pero si va a C, no existe
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            //Nuevo destino
        }

    } 
}
