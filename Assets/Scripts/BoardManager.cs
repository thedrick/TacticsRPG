using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private DefaultBoard _board;

    void Start()
    {
        foreach (CustomTileData d in _board.tileData)
        {
            if (d == null)
            {
                continue;
            }
            Tile tile = (Tile)ScriptableObject.CreateInstance("Tile");
            tile.sprite = d.sprite;
            _tilemap.SetTile(d.position, tile);
        }
    }

    public void HighlightTiles(CustomTileData[] tiles)
    {

    }
}
