using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class Tool_Method
{
    /// <summary>
    /// Find a random point on navmesh map
    /// </summary>
    /// <returns>Vector3 position</returns>
    public static Vector3 Get_Random_Location()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
        int t = Random.Range(0, navMeshData.indices.Length - 3);
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        point = Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);
        return point;
    }

    /// <summary>
    /// Create a prefab at random position in navmesh data
    /// </summary>
    /// <param name="prefab">Gameobject to create</param>
    public static void Create_New_AI_Object(GameObject prefab)
    {
        Vector3 temp_Pos = Tool_Method.Get_Random_Location();
        GameObject.Instantiate(prefab, temp_Pos, Quaternion.identity).SetActive(true);

        Debug.Log("Generated Object: " + prefab.ToString() + "At Position: " + temp_Pos);
        Particle_Manager.Instance.Enter_Scene(temp_Pos);
    }
    /// <summary>
    /// Create a prefab at given position at a cloest point in navmesh data
    /// </summary>
    /// <param name="prefab">Gameobject to create</param>
    /// <param name="position">Position to create</param>
    public static void Create_New_AI_Object(GameObject prefab, Vector3 position)
    {
        NavMesh.SamplePosition(position, out NavMeshHit hit_Info, 0.5f, NavMesh.AllAreas);
        Vector3 temp_Pos = hit_Info.position;
        GameObject.Instantiate(prefab, temp_Pos, Quaternion.identity).SetActive(true);

        Debug.Log("Generated Object: " + prefab.ToString() + "At Position: " + temp_Pos);
        Particle_Manager.Instance.Enter_Scene(temp_Pos);
    }
}
