using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomWalkGen : AbstractDungeonGen
{

	[SerializeField]
	protected RandomWalkSO randomWalkParamiters;

	protected override void RunPCG() {
		HashSet<Vector2Int> floorPos = RunRandomWalk(randomWalkParamiters, startPos);
		tilemapVisualizer.Clear();
		tilemapVisualizer.PaintFloorTiles(floorPos);
		WallGen.CreateWalls(floorPos, tilemapVisualizer);
	}

	protected HashSet<Vector2Int> RunRandomWalk(RandomWalkSO parameters, Vector2Int positition) {
		var currentPos = positition;
		HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
		for (int i = 0; i < parameters.iterations; i++) {
			var path = PCG.SimpleRandomWalk(currentPos, parameters.walkLength);
			floorPos.UnionWith(path);
			if (parameters.startRandomly) {
				currentPos = floorPos.ElementAt(Random.Range(0, floorPos.Count));
			}
		}
		return floorPos;
	}
}
