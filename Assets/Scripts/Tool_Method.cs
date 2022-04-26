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
}
