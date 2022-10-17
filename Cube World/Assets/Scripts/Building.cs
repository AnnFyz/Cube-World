using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2Int Size = Vector2Int.one;

    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color = new Color(0, 1, 0, 03f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1f, 0.1f, 1f));
            }
        }
    }
}
