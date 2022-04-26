using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Escape : MonoBehaviour
{
    private NavMeshAgent nav_Agent;
    public GameObject escape_Target;
    public float escape_Distance;
    private Vector3 move_Position;
    private AI_State ai_State;
    private NavMeshHit hit_Info;

    /// Two State for random moving or escape from selected target
    private enum AI_State
    {
        EscapeTarget,
        RandomMove
    }

    private void Awake()
    {
        nav_Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //initialize ai state
        if (Vector3.Distance(escape_Target.transform.position, transform.position) >= escape_Distance)
        {
            ai_State = AI_State.RandomMove;
        }
        else
        {
            ai_State = AI_State.EscapeTarget;
        }
    }

    private void Update()
    {
        if ((ai_State == AI_State.EscapeTarget) && !nav_Agent.pathPending)
        {
            //Escape mode
            move_Position = transform.position - escape_Target.transform.position + transform.position;
            NavMesh.SamplePosition(move_Position, out hit_Info, escape_Distance, NavMesh.AllAreas);
            nav_Agent.SetDestination(hit_Info.position);
            Debug.Log("Escape Mode new destination Set");
        }
        else if ((ai_State == AI_State.RandomMove) && !nav_Agent.pathPending)
        {
            //Random mode
            if (nav_Agent.remainingDistance <= nav_Agent.stoppingDistance)
            {
                nav_Agent.SetDestination(Tool_Method.Get_Random_Location());
                Debug.Log("Random Mode new destination Set");
            }
        }
    }

    //Trigger switch AI state
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ai_State = AI_State.EscapeTarget;
            Debug.Log("AI Sate Switched to Escape Mode");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ai_State = AI_State.RandomMove;
            Debug.Log("AI Sate Switched to Random Mode");
        }
    }
}
