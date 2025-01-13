using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomPointGenerator : MonoBehaviour
{
    public static Vector3 randomPointGen(Vector3 Start_Point, float radius)
    {
        Vector3 Dir = Random.insideUnitSphere * radius;
        Dir += Start_Point;
        NavMeshHit Hit_;
        Vector3 Final_Pos = Vector3.zero;
        if(NavMesh.SamplePosition(Dir, out Hit_, radius, 1))
        {
            Final_Pos = Hit_.position;
        }
        return Final_Pos;
    }
}
