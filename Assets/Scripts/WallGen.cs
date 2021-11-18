using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGen {
	public static void CreateWalls(HashSet<Vector2Int> floorPos, 
        TilemapVisualizer tilemapVisualizer) {

		var basicWallPositions = FindWallsInDirections(floorPos,
			 Direction2D.cardnalDirectionsList);
		var cornerWallPositions = FindWallsInDirections(floorPos,
		 	Direction2D.diagonalDirectionsList);

		CreateBasicWalls(tilemapVisualizer, basicWallPositions, floorPos);
		CreateCornerWalls(tilemapVisualizer, cornerWallPositions, floorPos);
	}

	private static void CreateCornerWalls(TilemapVisualizer tilemapVisualizer,
	 HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> floorPos) {
		foreach (var position in cornerWallPositions){
			string neighboursBinaray = "";
			foreach(var direction in Direction2D.eightDirectionsList){
				var neighbourPosition = position + direction;
				if (floorPos.Contains(neighbourPosition)){
					neighboursBinaray += "1";
				} else {
					neighboursBinaray += "0";
				}
			}
			tilemapVisualizer.PaintSingleCornerWall(position, neighboursBinaray);
		}
	}

	private static void CreateBasicWalls(TilemapVisualizer tilemapVisualizer,
	HashSet<Vector2Int> basicWallPositions, HashSet<Vector2Int> floorPositions) {
		
		foreach (var position in basicWallPositions) {
			string neighboursBinaray = "";
			foreach(var direction in Direction2D.cardnalDirectionsList){
				var neighbourPosition = position + direction;
				if(floorPositions.Contains(neighbourPosition)){
					neighboursBinaray += "1";
				}else {
					neighboursBinaray += "0";
				}
			}

			tilemapVisualizer.PaintSingleBasicWall(position, neighboursBinaray);
		}
	}

	private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPos, 
        List<Vector2Int> directionList) {
		
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
		foreach (var position in floorPos) {
			foreach (var direction in directionList) {
				var neighbourPosition = position + direction;
				if (floorPos.Contains(neighbourPosition) == false) {
					wallPositions.Add(neighbourPosition);
				}
			}
		}
		return wallPositions;
	}
}
