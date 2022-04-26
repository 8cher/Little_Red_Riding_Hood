using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Chase : MonoBehaviour
{
    private NavMeshAgent nav_Agent;
    public GameObject Chase_Target;
    private void Awake()
    {
        nav_Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        nav_Agent.SetDestination(Chase_Target.gameObject.transform.position);
    }
}