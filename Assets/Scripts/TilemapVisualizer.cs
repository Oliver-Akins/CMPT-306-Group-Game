using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour {
	[SerializeField]
	private Tilemap floorTilemap, wallTilemap;
	[SerializeField]
	private TileBase floorTile, wallTop;

	public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions) {
		PaintTiles(floorPositions, floorTilemap, floorTile);
	}

	internal void PaintSingleBasicWall(Vector2Int position) {
		PaintSingleTile(wallTilemap, wallTop, position);
	}

	private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile) {
		foreach (var position in positions) {
			PaintSingleTile(tilemap, tile, position);
		}
	}

	private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position) {
		var tilePosition = tilemap.WorldToCell((Vector3Int)position);
		tilemap.SetTile(tilePosition, tile);
	}

	public void AddItem(Vector2Int position, GameObject item){
		Vector2 adjusted = position;
		adjusted += new Vector2(0.5f, 0.5f);
		
		Instantiate(item,(Vector3) adjusted, Quaternion.identity);
	}

	public void Clear() {
		floorTilemap.ClearAllTiles();
		wallTilemap.ClearAllTiles();
	}
}
