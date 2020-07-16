using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RawTileData
{
    public string sprite;
    public int x;
    public int y;
    public int z;

    public static RawTileData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<RawTileData>(jsonString);
    }
}

[System.Serializable]
public class RawMapData
{
    public RawTileData[] tiles;

    public static RawMapData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<RawMapData>(jsonString);
    }
}

public class CustomTileData
{
    public CustomTileData(Sprite sprite, Vector3Int position)
    {
        this.sprite = sprite;
        this.position = position;
    }

    public CustomTileData(RawTileData raw)
    {
        this.sprite = Resources.Load<Sprite>("Sprites/" + raw.sprite);
        this.position = new Vector3Int(raw.x, raw.y, raw.z);
    }

    public Sprite sprite { get; }
    public Vector3Int position { get; }
}
