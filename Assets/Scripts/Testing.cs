using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Testing : MonoBehaviour
{
    [SerializeField] private CharacterPathFinding characterPathfinding;
    [SerializeField] private CharacterClass player;

    private PathFinding pathFinding;
    private Grid<Node> grid;

    void Start()
    {
        pathFinding = new PathFinding(40, 40);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            characterPathfinding.SetTargetPosition(mouseWorldPosition);
        }
    }
}
