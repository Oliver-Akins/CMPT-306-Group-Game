using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGen {
	public static void CreateWalls(HashSet<Vector2Int> floorPos, 
        TilemapVisualizer tilemapVisualizer) {
		
        var basicWallPositions = FindWallsInDirections(floorPos, Direction2D.cardnalDirectionsList);
		foreach (var position in basicWallPositions) {
			tilemapVisualizer.PaintSingleBasicWall(position);
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
