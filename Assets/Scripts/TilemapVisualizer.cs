using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour {
	[SerializeField]
	private Tilemap floorTilemap, wallTilemap, clutterTilemap;
	[SerializeField]
	private TileBase floorTile, wallTop, wallSideRight, wallSideLeft, wallBottom,
	wallFull, wallInnerDownLeft, wallInnerDownRight, wallDiagonalDownRight,
	wallDiagonalDownLeft, wallDiagonalUpRight, wallDiagonalUpLeft;

	[SerializeField]
	[Range(0.001f, 0.2f)]
	private float clutterChance = 0.05f;

	[SerializeField]
	private GameObject tileGlow;

	[SerializeField]
	private TileBase lavaClutter1, lavaClutter2, lavaClutter3, lavaClutter4, 
	stoneClutter1, stoneClutter2, stoneClutter3, stoneClutter4,
	coalClutter1, coalClutter2, coalClutter3, coalClutter4,
	brushClutter1, brushClutter2, brushClutter3, brushClutter4,
	boneClutter1, boneClutter2;

	[SerializeField]
	private GameObject navWall;

	public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions) {
		PaintTiles(floorPositions, floorTilemap, floorTile);
		PaintClutterTiles(floorPositions, clutterTilemap, clutterChance);
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

		if (tile != null) {
			Instantiate(
				this.navWall,
				(Vector2)position + (Vector2.one/2),
				Quaternion.identity
			);
			PaintSingleTile(wallTilemap, tile, position);
		}
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

		if (tile != null) {
			Instantiate(
				this.navWall,
				(Vector2)position + (Vector2.one/2),
				Quaternion.identity
			);
			PaintSingleTile(wallTilemap, tile, position);
		}
	}

	private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile) {
		foreach (var position in positions) {
			PaintSingleTile(tilemap, tile, position);
		}
	}

	private void PaintClutterTiles(IEnumerable<Vector2Int> positions,
	Tilemap tilemap, float chancePerTile) {

		foreach (var position in positions) {
			if (UnityEngine.Random.value < chancePerTile){
				int tileNumber = UnityEngine.Random.Range(0, 18);
				TileBase clutterTile = lavaClutter1;
				switch (tileNumber)
				{
					case 0: clutterTile = lavaClutter1; AddItem(position, tileGlow); break;
					case 1: clutterTile = lavaClutter2; AddItem(position, tileGlow); break;
					case 2: clutterTile = lavaClutter3; AddItem(position, tileGlow); break;
					case 3: clutterTile = lavaClutter4; AddItem(position, tileGlow); break;
					case 4: clutterTile = stoneClutter1; break;
					case 5: clutterTile = stoneClutter2; break;
					case 6: clutterTile = stoneClutter3; break;
					case 7: clutterTile = stoneClutter4; break;
					case 8: clutterTile = coalClutter1; break;
					case 9: clutterTile = coalClutter2; break;
					case 10: clutterTile = coalClutter3; break;
					case 11: clutterTile = coalClutter4; break;
					case 12: clutterTile = brushClutter1; break;
					case 13: clutterTile = brushClutter2; break;
					case 14: clutterTile = brushClutter3; break;
					case 15: clutterTile = brushClutter4; break;
					case 16: clutterTile = boneClutter1; break;
					case 17: clutterTile = boneClutter2; break;
					default: Debug.Log("error: tilenumber for clutter out of range"); break;
				}

				PaintSingleTile(tilemap, clutterTile, position);
			}
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
