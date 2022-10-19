using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    [SerializeField] int xGridSize = 10;
    [SerializeField] int yGridSize = 10;
    public Vector2Int gridSize;
    private Building[,] grid;
    private Building flyingBuilding;
    private Camera mainCamera;

    private void OnDrawGizmos()
    {
        for (int x = 0; x < xGridSize; x++)
        {
            for (int y = 0; y < yGridSize; y++)
            {
                Gizmos.color = new Color(0, 1, 0, 03f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1f, 0.1f, 1f));
            }
        }
    }
    private void Awake()
    {
        gridSize = new Vector2Int(xGridSize, yGridSize);
        grid = new Building[gridSize.x, gridSize.y];
        mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if(flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if(flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero); //endless ground https://docs.unity3d.com/ScriptReference/Plane.html
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // cursors position

            if (groundPlane.Raycast(ray, out float position)) // if plane intersects with cursor
            {
                Vector3 worldPosition = ray.GetPoint(position); // position where Player clicked
                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);
                Debug.Log(worldPosition);
                bool avialable = true;
                //if (x < 0 || x > gridSize.x - flyingBuilding.Size.x) avialable = false; //checking doesn't work correct
                //if (y < 0 || y > gridSize.y - flyingBuilding.Size.y) avialable = false;
                //if (avialable && IsPlaceTaken(x, y)) avialable = false;
                flyingBuilding.transform.position = new Vector3(x, 0, y); // Building placing

                if (avialable && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(x,y);
                }
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if(grid[placeX + x, placeY + y] != null) return true;
            }
        }
        return false;
    }
    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        //for (int x = 0; x < flyingBuilding.Size.x; x++)
        //{
        //    for (int y = 0; y < flyingBuilding.Size.y; y++)
        //    {
        //        grid[placeX + x, placeY + y] = flyingBuilding;
        //    }
        //}
        flyingBuilding = null;
    }
}

