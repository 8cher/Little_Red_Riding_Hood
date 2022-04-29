using UnityEngine;
using UnityEngine.AI;

public class AI_Random : MonoBehaviour
{
    private NavMeshAgent nav_Agent;

    private void Awake()
    {
        nav_Agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        nav_Agent.SetDestination(Tool_Method.Get_Random_Location());
    }

    private void Update()
    {
        if (nav_Agent.remainingDistance <= nav_Agent.stoppingDistance)
        {
            nav_Agent.SetDestination(Tool_Method.Get_Random_Location());
        }
    }
}
