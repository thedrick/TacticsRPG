using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DefaultBoard : MonoBehaviour
{
    [SerializeField]
    private string _mapName;
    private int minX = 0;
    private int maxX = 0;
    private int minY = 0;
    private int maxY = 0;

    public CustomTileData[,] tileData;

    public bool ContainsPoint(int x, int y)
    {
        return x >= minX && x <= maxX && y >= minY && y <= maxY;
    }

    private void Awake()
    {
        LoadMap();
    }

    private void LoadMap()
    {
        var jsonTextFile = Resources.Load<TextAsset>("Maps/" + _mapName);
        RawMapData mapData = JsonUtility.FromJson<RawMapData>(jsonTextFile.text);

        foreach (RawTileData d in mapData.tiles)
        {
            minX = Math.Min(d.x, minX);
            maxX = Math.Max(d.x, maxX);
            minY = Math.Min(d.y, minY);
            maxY = Math.Max(d.y, maxY);
        }

        int totalXCount = Math.Abs(minX) + Math.Abs(maxX) + 1;
        int totalYCount = Math.Abs(minY) + Math.Abs(maxY) + 1;
        tileData = new CustomTileData[totalXCount, totalYCount];

        foreach (RawTileData d in mapData.tiles)
        {
            tileData[d.x, d.y] = new CustomTileData(d);
        }
    }
}
