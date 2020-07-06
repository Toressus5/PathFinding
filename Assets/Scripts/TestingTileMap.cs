using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestingTileMap : MonoBehaviour
{
    public Tilemap tilemap;
    public List<Vector3> tileWorldLocations;

    void Start()
    {
        tileWorldLocations = new List<Vector3>();

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localTileCoordinates = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 tileCoordinates = tilemap.CellToWorld(localTileCoordinates);
            if (tilemap.HasTile(localTileCoordinates))
            {
                tileWorldLocations.Add(tileCoordinates);
                SetUnwalkableWalls(tileCoordinates);
            }
        }
    }

    private void SetUnwalkableWalls(Vector3 wallCordinates)
    {
        PathFinding.Instance.GetGrid().GetXY(wallCordinates, out int x, out int y);
        PathFinding.Instance.GetNode(x, y).SetIsWalkable(!PathFinding.Instance.GetNode(x, y).isWalkable);
    }
}
