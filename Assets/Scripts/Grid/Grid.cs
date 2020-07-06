using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid<GridObject> {

    public event EventHandler<OnGridValueChangedEventArgs> OnGridObjectChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridArray;
    private TextMesh[,] textArray;
    private Vector3 originPosition;

    public Grid(int width, int height, float cellSize, Vector3 originPoisition, Func<Grid<GridObject>, int, int, GridObject> createObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPoisition;

        gridArray = new GridObject[width, height];
        textArray = new TextMesh[width, height];


        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createObject(this, x, y);
            }
        }

        bool debugGrid = false;
        if (debugGrid == true)
        {
            DebugGrid();
        }
    }

    public int GetHeight()
    {
        return height;
    }

    public int GetWidth()
    {
        return width;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void GetXY(Vector3 worldPoisition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPoisition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPoisition - originPosition).y / cellSize);
    }

    public void ChangeGridObject(int x, int y, GridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            textArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void ChangeGridObject(Vector3 worldPosition, GridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        ChangeGridObject(x, y, value);
    }

    public GridObject GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(GridObject);
        }
    }

    public GridObject GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }

    public void TriggerGridObjectChanged(int x, int y)
    {
        if(OnGridObjectChanged != null)
        {
            OnGridObjectChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }

    public void DebugGrid()
    {
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                textArray[x, y] = CreateText.CreateTextInWorld(null, gridArray[x, y]?.ToString(), GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, 10, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.red, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.red, 100f);
            }
        }
    }
}
