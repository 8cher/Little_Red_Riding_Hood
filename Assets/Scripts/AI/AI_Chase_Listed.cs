using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Chase_Listed : MonoBehaviour
{
    private NavMeshAgent nav_Agent;
    private GameObject current_Target;
    private float minimum_Distance = 10f;
    private float temp_Distance;

    private void Awake()
    {
        nav_Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        foreach (GameObject target in GameManager_Hunter.list_Red_Hood)
        {
            temp_Distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
            if (temp_Distance <= minimum_Distance)
            {
                minimum_Distance = temp_Distance;
                current_Target = target;
            }
        }
        if ((current_Target != null) || (nav_Agent.remainingDistance <= nav_Agent.stoppingDistance))
        {
            nav_Agent.SetDestination(current_Target.gameObject.transform.position);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AI") && !other.isTrigger)
        {
            Character_Info temp = other.GetComponent<Character_Info>();

            if (temp.type == Character_Info.Character_Type.Red_Hood)
            {
                GameManager_Hunter.list_Red_Hood.Remove(other.gameObject.transform.parent.parent.gameObject);
                Destroy(other.gameObject.transform.parent.parent.gameObject);
                Particle_Manager.Instance.Exit_Scene(other.gameObject.transform.position);
                GameManager_Hunter.remaining_RedHood--;
                Debug.Log("AI Wolf Trigger:Catch RH");
                minimum_Distance = 10f;
            }
        }
    }
}