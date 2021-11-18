using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorridorFirstDungeonGen : RandomWalkGen
{
	[SerializeField]
	private int corridorLength = 30;

	[SerializeField]
	[Range(0.01f, 1)]
	private float roomPercent = 1.0f;

	[SerializeField]
	private int numberOfRooms = 11; //if using a room percent < 1 this is the max number of rooms

	[SerializeField]
	private GameObject nextLevelHole;


	[SerializeField]
	private GameObject coin;
	[SerializeField]
	[Range(0.0001f, 0.1f)]
	private float coinPercent = 0.05f;

	[SerializeField]
	private GameObject coinStack;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float coinStackPercent = 0.005f;

	[SerializeField]
	private GameObject potion;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float potionPercent = 0.005f;

	[SerializeField]
	private GameObject poison;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float poisonPercent = 0.001f;

	[SerializeField]
	private GameObject allStatUp;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float allStatUpPercent = 0.0001f;

	[SerializeField]
	private GameObject agilityUp;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float agilityUpPercent = 0.0005f;


	[SerializeField]
	private GameObject healthUp;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float healthUpPercent = 0.0005f;

	[SerializeField]
	private GameObject strenghtUp;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float strenghtUpPercent = 0.0005f;

	[SerializeField]
	private GameObject staminaUp;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float staminaUpPercent = 0.0005f;

	[SerializeField]
	private GameObject key;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float keyPercent = 0.005f;

	[SerializeField]
	private GameObject zombie;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float zombiePercent = 0.005f;

	[SerializeField]
	private GameObject skeleton;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float skeletonPercent = 0.005f;

	[SerializeField]
	private GameObject vampire;
	[SerializeField]
	[Range(0.0001f, 0.02f)]
	private float vampirePercent = 0.001f;




	private void Start() {
		GenerateDungeon();
	}


	protected override void RunPCG() {
		CorridorFirstGen();
	}

	private void CorridorFirstGen() {
		HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
		HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

		CreateCorridors(floorPositions, potentialRoomPositions);
		HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);

		List<Vector2Int> deadEnds = FindAllDeadEnds(floorPositions);

		CreatRoomsAtDeadEnds(deadEnds, roomPositions);
		HashSet<Vector2Int> posibleItemPositions = new HashSet<Vector2Int>(roomPositions);
		HashSet<Vector2Int> posibleEnimiePositions = new HashSet<Vector2Int>(roomPositions);


		floorPositions.UnionWith(roomPositions);

		tilemapVisualizer.PaintFloorTiles(floorPositions);

		AddItemRandomly(zombie, zombiePercent, posibleEnimiePositions);
		AddItemRandomly(skeleton, skeletonPercent, posibleEnimiePositions);
		AddItemRandomly(vampire, vampirePercent, posibleEnimiePositions);


		AddItemRandomly(coinStack, coinStackPercent, posibleItemPositions);
		AddItemRandomly(key, keyPercent, posibleItemPositions);
		AddItemRandomly(potion, potionPercent, posibleItemPositions);
		AddItemRandomly(poison, poisonPercent, posibleItemPositions);
		
		AddItemRandomly(strenghtUp, strenghtUpPercent, posibleItemPositions);
		AddItemRandomly(healthUp, healthUpPercent, posibleItemPositions);
		AddItemRandomly(staminaUp, staminaUpPercent, posibleItemPositions);
		AddItemRandomly(agilityUp, agilityUpPercent, posibleItemPositions);

		AddItemRandomly(coin, coinPercent, posibleItemPositions);
		AddItemRandomly(allStatUp, allStatUpPercent, posibleItemPositions);
		
		
		WallGen.CreateWalls(floorPositions, tilemapVisualizer);
	}

	private void AddItemRandomly(GameObject item, float chancePerTile, HashSet<Vector2Int> positions){
		HashSet<Vector2Int> usedPositions = new HashSet<Vector2Int>();
		foreach(Vector2Int position in positions){
			if(UnityEngine.Random.value < chancePerTile){
				tilemapVisualizer.AddItem(position, item);
				usedPositions.Add(position);
			}
		}
		foreach(Vector2Int position in usedPositions){
			positions.Remove(position);
		}
	}


	private void CreatRoomsAtDeadEnds(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomFloors) {
		foreach (var position in deadEnds) {
			if (roomFloors.Contains(position) == false) {
				var room = RunRandomWalk(randomWalkParamiters, position);
				roomFloors.UnionWith(room);
			}
		}
	}

	private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPositions) {
		List<Vector2Int> deadEnds = new List<Vector2Int>();
		foreach (var position in floorPositions) {
			int neighboursCount = 0;
			foreach (var direction in Direction2D.cardnalDirectionsList) {
				if (floorPositions.Contains(position + direction)) {
					neighboursCount++;
				}
			}
			if (neighboursCount == 1) {
				deadEnds.Add(position);
			}
		}
		return deadEnds;
	}

	private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions) {
		HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
		int roomToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * roomPercent);
		List<Vector2Int> roomToCreate = potentialRoomPositions.OrderBy(x =>
            Guid.NewGuid()).Take(roomToCreateCount).ToList();

		foreach (var roomPosition in roomToCreate) {
			var roomFloor = RunRandomWalk(randomWalkParamiters, roomPosition);
			roomPositions.UnionWith(roomFloor);
		}
		return roomPositions;
	}

	private void CreateCorridors(HashSet<Vector2Int> floorPositions,
    HashSet<Vector2Int> potentialRoomPositions) {

		var currentPos = startPos;
		potentialRoomPositions.Add(currentPos);

		
		while (potentialRoomPositions.Count < numberOfRooms) {
			var corridor = PCG.RandomWalkCorridor(currentPos, corridorLength);
			currentPos = corridor[corridor.Count - 1];
			potentialRoomPositions.Add(currentPos);
			floorPositions.UnionWith(corridor);
		}

		tilemapVisualizer.AddItem(currentPos, nextLevelHole);

	}
}
