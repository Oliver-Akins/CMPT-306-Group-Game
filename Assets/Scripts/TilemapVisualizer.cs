using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour {
	[SerializeField]
	private Tilemap floorTilemap, wallTilemap;
	[SerializeField]
	private TileBase floorTile, wallTop, wallSideRight, wallSideLeft, wallBottom, 
	wallFull, wallInnerDownLeft, wallInnerDownRight, wallDiagonalDownRight, 
	wallDiagonalDownLeft, wallDiagonalUpRight, wallDiagonalUpLeft;

	public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions) {
		PaintTiles(floorPositions, floorTilemap, floorTile);
	}

	internal void PaintSingleBasicWall(Vector2Int position, string binaryType) {
		int typeAsInt = Convert.ToInt32(binaryType, 2);
		TileBase tile = null;
		if(WallHelper.wallTop.Contains(typeAsInt)){
			tile = wallTop;
		} 
		else if(WallHelper.wallSideRight.Contains(typeAsInt)){
			tile = wallSideRight;
		}
		else if(WallHelper.wallSideLeft.Contains(typeAsInt)){
			tile = wallSideLeft;
		}
		else if(WallHelper.wallBottm.Contains(typeAsInt)){
			tile = wallBottom;
		}
		else if(WallHelper.wallFull.Contains(typeAsInt)){
			tile = wallFull;
		}

		if (tile != null) PaintSingleTile(wallTilemap, tile, position);
	}

	internal void PaintSingleCornerWall(Vector2Int position, string binaryType) {
		
		int typeAsInt = Convert.ToInt32(binaryType, 2);
		
		TileBase tile = null;

		if(WallHelper.wallInnerCornerDownLeft.Contains(typeAsInt)){
			tile = wallInnerDownLeft;
		}
		else if(WallHelper.wallInnerCornerDownRight.Contains(typeAsInt)){
			tile = wallInnerDownRight;
		}
		else if(WallHelper.wallDiagonalCornerDownLeft.Contains(typeAsInt)){
			tile = wallDiagonalDownLeft;
		}
		else if(WallHelper.wallDiagonalCornerDownRight.Contains(typeAsInt)){
			tile = wallDiagonalDownRight;
		}
		else if(WallHelper.wallDiagonalCornerUpLeft.Contains(typeAsInt)){
			tile = wallDiagonalUpLeft;
		}
		else if(WallHelper.wallDiagonalCornerUpRight.Contains(typeAsInt)){
			tile = wallDiagonalUpRight;
		}
		else if(WallHelper.wallFullEightDirections.Contains(typeAsInt)){
			tile = wallFull;
		}
		else if(WallHelper.wallBottmEightDirections.Contains(typeAsInt)){
			tile = wallBottom;
		}

		if (tile != null) PaintSingleTile(wallTilemap, tile, position);
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
