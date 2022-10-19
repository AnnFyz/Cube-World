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
            Destroy(flyingBuilding);
        }

        flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if(flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero); //endless ground
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(groundPlane.Raycast(ray, out float position)) // if plane intersects with cursor
            {
                Vector3 worldPosition = ray.GetPoint(position); // position where Player clicked

                flyingBuilding.transform.position = worldPosition;
            }
        }
    }
}

