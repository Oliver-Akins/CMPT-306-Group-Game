using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGen : MonoBehaviour {
    [SerializeField]
    protected TilemapVisualizer tilemapVisualizer = null;

    [SerializeField]
    protected Vector2Int startPos = Vector2Int.zero;

    public void GenerateDungeon() {
        tilemapVisualizer.Clear();
        RunPCG();
    }

    protected abstract void RunPCG();
}
