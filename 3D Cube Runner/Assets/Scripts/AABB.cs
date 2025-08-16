// AABB.cs
using UnityEngine;

public struct AABB
{
    public Vector3 min;
    public Vector3 max;

    public AABB(Vector3 center, Vector3 size)
    {
        Vector3 half = size * 0.5f;
        min = center - half;
        max = center + half;
    }

    public static bool CheckCollision(AABB a, AABB b)
    {
        return (a.min.x <= b.max.x && a.max.x >= b.min.x) &&
               (a.min.y <= b.max.y && a.max.y >= b.min.y) &&
               (a.min.z <= b.max.z && a.max.z >= b.min.z);
    }
}
