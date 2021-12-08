using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CorridorFirstDungeonGen : RandomWalkGen
{
	private ArrayList rooms;
	private HashSet<Vector2Int> coridorPositions;

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

	// uses the same percent as the keys when being generated
	[SerializeField]
	private GameObject chest;

	[SerializeField]
	private GameObject zombie;
	
	[SerializeField]
	private GameObject skeleton;
	
	[SerializeField]
	private GameObject vampire;

	[SerializeField]
	private GameObject candlelight;



	// Expose the final level map so that the enemies can use it for pathfinding
	private HashSet<Vector2Int> _finalLevel = null;
	public HashSet<Vector2Int> finalLevel {
		get {
			return this._finalLevel;
		}
		private set {
			this._finalLevel = value;
		}
	}

	private void Start() {
		GenerateDungeon();
	}


	protected override void RunPCG() {
		CorridorFirstGen();
	}

	private void CorridorFirstGen() {
		HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
		HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();
		rooms = new ArrayList();
		coridorPositions = new HashSet<Vector2Int>();

		CreateCorridors(floorPositions, potentialRoomPositions);
		HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);

		List<Vector2Int> deadEnds = FindAllDeadEnds(floorPositions);

		CreatRoomsAtDeadEnds(deadEnds, roomPositions);
		HashSet<Vector2Int> posibleItemPositions = new HashSet<Vector2Int>(roomPositions);
		posibleItemPositions.RemoveWhere(coridorPositions.Contains);


		floorPositions.UnionWith(roomPositions);

		tilemapVisualizer.PaintFloorTiles(floorPositions);

		AddEnemys();


		AddItemRandomly(coinStack, coinStackPercent, posibleItemPositions);
		AddEqualKeysAndChestsRandomly(key, chest, keyPercent, posibleItemPositions);
		AddItemRandomly(potion, potionPercent, posibleItemPositions);
		AddItemRandomly(poison, poisonPercent, posibleItemPositions);

		AddItemRandomly(strenghtUp, strenghtUpPercent, posibleItemPositions);
		AddItemRandomly(healthUp, healthUpPercent, posibleItemPositions);
		AddItemRandomly(staminaUp, staminaUpPercent, posibleItemPositions);
		AddItemRandomly(agilityUp, agilityUpPercent, posibleItemPositions);

		AddItemRandomly(coin, coinPercent, posibleItemPositions);
		AddItemRandomly(allStatUp, allStatUpPercent, posibleItemPositions);

		spawnLights();

		WallGen.CreateWalls(floorPositions, tilemapVisualizer);
		this.finalLevel = floorPositions;
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

	/**
		Still want a random number of keys and chests to be generated but in
		equal amounts. This toggles the generation of keys and chests, if 
		only an odd number of generations happen, there will always be one more
		key than chests. If even there will be an even number of generations.
		This also allows for keys to be near chests instead of it being completely 
		random, potentially causing backtracking.

		Enemies also no longer drop keys
	*/	
	private void AddEqualKeysAndChestsRandomly(GameObject key,
	GameObject chest, float chancePerTile, HashSet<Vector2Int> positions){
		HashSet<Vector2Int> usedPositions = new HashSet<Vector2Int>();
		bool toggleItem = true;
		foreach(Vector2Int position in positions){
			if(UnityEngine.Random.value < chancePerTile){
				if (toggleItem){
					tilemapVisualizer.AddItem(position, key);
				} else {
					tilemapVisualizer.AddItem(position, chest);
				}
				toggleItem = !toggleItem;
				usedPositions.Add(position);
			}
		}
		foreach(Vector2Int position in usedPositions){
			positions.Remove(position);
		}
	}

	private void AddEnemys(){
		foreach(HashSet<Vector2Int> room in rooms){
			HashSet<Vector2Int> avalibleSpotsHash = new HashSet<Vector2Int>(room);
			List<Vector2Int> avalibleSpots = avalibleSpotsHash.ToList();
			if (avalibleSpots.Contains(Vector2Int.one)){
				HashSet<Vector2Int> spawnArea = SquareArea(5,5, startPos);
				avalibleSpots.RemoveAll(spawnArea.Contains);
			}

			int max = 5 + (GameStateManager.Instance.level / 2);
			int min = 2 + (GameStateManager.Instance.level / 4);
			int leftToSpawn = UnityEngine.Random.Range(min, max);

			while (leftToSpawn > 0 && avalibleSpots.Count() > 0){
				int spawnType = UnityEngine.Random.Range(0, 5);
				GameObject enemy = zombie;
				switch (spawnType) {
					case 0:
					case 1: enemy = zombie; break;
					case 2:
					case 3: enemy = skeleton; break;
					case 4: enemy = vampire; break;
					default: Debug.Log("ERROR: invaled enemy type index"); break;
				}
				
				Vector2Int positon = avalibleSpots[(UnityEngine.Random.Range(0, avalibleSpots.Count))];
				tilemapVisualizer.AddItem(positon, enemy);
				avalibleSpots.Remove(positon);
				leftToSpawn -= 1;
			}
		}
	}

	private HashSet<Vector2Int> SquareArea(int xRadius, int yRadius, Vector2Int startPosition){
		HashSet<Vector2Int> area = new HashSet<Vector2Int>();
		for (int x = -xRadius; x <= xRadius; x++){
			for (int y = -yRadius; y <= yRadius; y++){
				area.Add(startPosition + new Vector2Int(x,y));
			}
		}

		return area;
	}



	public void spawnLights(){
		foreach(HashSet<Vector2Int> room in rooms){
			HashSet<Vector2Int> avalibleSpotsHash = new HashSet<Vector2Int>(room);
			avalibleSpotsHash.RemoveWhere(coridorPositions.Contains);
			List<Vector2Int> avalibleSpots = avalibleSpotsHash.ToList();

			int max = 8;
			int min = 3;
			int leftToSpawn = UnityEngine.Random.Range(min, max);

			while (leftToSpawn > 0 && avalibleSpots.Count() > 0){
				
				Vector2Int positon = avalibleSpots[(UnityEngine.Random.Range(0, avalibleSpots.Count))];
				tilemapVisualizer.AddItem(positon, candlelight);
				avalibleSpots.Remove(positon);
				HashSet<Vector2Int> spawnArea = SquareArea(4,4, positon);
				avalibleSpots.RemoveAll(spawnArea.Contains);
				leftToSpawn -= 1;
			}
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
			roomFloor.Remove(roomPosition);
			rooms.Add(roomFloor);
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
			coridorPositions.UnionWith(corridor);
		}

		tilemapVisualizer.AddItem(currentPos, nextLevelHole);

	}
}
