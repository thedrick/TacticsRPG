using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private DefaultBoard _board;

    private Vector3Int _currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        _currentPosition = Vector3Int.zero;
        UpdateCursorPosition(Vector3Int.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            UpdateCursorPosition(Vector3Int.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            UpdateCursorPosition(Vector3Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            UpdateCursorPosition(Vector3Int.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            UpdateCursorPosition(Vector3Int.right);
        }
    }

    void UpdateCursorPosition(Vector3Int offset)
    {
        Vector3Int newPosition = _currentPosition + offset;
        
        if (!_board.ContainsPoint(newPosition.x, newPosition.y))
        {
            return;
        }

        _currentPosition += offset;

        CustomTileData tileData = _board.tileData[_currentPosition.x, _currentPosition.y];
        Vector3Int offsetNeededForRenderingOnMap = new Vector3Int(1, 1, tileData.position.z);
        transform.position = _tilemap.CellToLocal(_currentPosition + offsetNeededForRenderingOnMap);
    }
}
