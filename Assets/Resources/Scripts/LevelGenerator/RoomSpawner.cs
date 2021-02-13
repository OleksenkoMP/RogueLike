using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int SizeOfGeneration = 1;
    public int openingDirection;
    // 1 = need top door
    // 2 = need bottom door
    // 3 = need right door
    // 4 = need left door

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    private GameObject Grid;

    public float waitTime = 10f;

    void Start()
    {
        Grid = GameObject.Find("Grid");
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Destroy(this.gameObject, waitTime);
        Invoke("Spawn", 0.1f + Random.Range(0, 0.2f));
    }

    void Spawn()
    {
        if (spawned == false)
        {
            switch (openingDirection)
            {
                case 1:
                    RoomCreator(templates.bottomRooms);
                    break;
                case 2:
                    RoomCreator(templates.topRooms);
                    break;
                case 3:
                    RoomCreator(templates.leftRooms);
                    break;
                case 4:
                    RoomCreator(templates.rightRooms);
                    break;
            }
            
            spawned = true;

        }

    }
    public struct Constraints
    {
        public int leftDoor;
        public int topDoor;
        public int rightDoor;
        public int bottomDoor;
    }
    private bool isRoomCorrect(GameObject room, Constraints constraints)
    {
        if (constraints.leftDoor != -1 && constraints.leftDoor != room.GetComponent<RoomInfo>().DoorL)
            return false;
        if (constraints.topDoor != -1 && constraints.topDoor != room.GetComponent<RoomInfo>().DoorT)
            return false;
        if (constraints.rightDoor != -1 && constraints.rightDoor != room.GetComponent<RoomInfo>().DoorR)
            return false;
        if (constraints.bottomDoor != -1 && constraints.bottomDoor != room.GetComponent<RoomInfo>().DoorB)
            return false;

        return true;
    }
    private void RoomCreator(GameObject[] rooms)
    {
        Constraints constraints = RoomChecker(!(templates.rooms.Count < SizeOfGeneration));
        List<GameObject> filteredRooms = new List<GameObject>();

        foreach (var room in rooms){
            if (isRoomCorrect(room, constraints))
                filteredRooms.Add(room);
        }

        
        if (filteredRooms.Count > 2)
        {
            rand = Random.Range(0, filteredRooms.Count);
        }
        else 
            rand = 0;

        Instantiate(filteredRooms[rand], transform.position, filteredRooms[rand].transform.rotation, Grid.transform);
        Destroy(gameObject);
    }

    private Constraints RoomChecker(bool isFinalization)
    {
        Constraints constraints = new Constraints();
        constraints.leftDoor = -1;
        constraints.topDoor = -1;
        constraints.rightDoor = -1;
        constraints.bottomDoor = -1;

        foreach (var item in templates.rooms)
        {
            if (item.transform.position == this.gameObject.transform.position + new Vector3(-7.36f, 0f, 0f))
            {
                constraints.leftDoor = item.GetComponent<RoomInfo>().DoorR;
            }
            if (item.transform.position == this.gameObject.transform.position + new Vector3(0f, 5.44f, 0f))
            {
                constraints.topDoor = item.GetComponent<RoomInfo>().DoorB;
            }
            if (item.transform.position == this.gameObject.transform.position + new Vector3(7.36f, 0f, 0f))
            {
                constraints.rightDoor = item.GetComponent<RoomInfo>().DoorL;
            }
            if (item.transform.position == this.gameObject.transform.position + new Vector3(0f, -5.44f, 0f))
            {
                constraints.bottomDoor = item.GetComponent<RoomInfo>().DoorT;
            }
        }



        if (isFinalization)
        {
            if (constraints.leftDoor == -1) constraints.leftDoor = 0;
            if (constraints.topDoor == -1) constraints.topDoor = 0;
            if (constraints.rightDoor == -1) constraints.rightDoor = 0;
            if (constraints.bottomDoor == -1) constraints.bottomDoor = 0;
        }

        return constraints;
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {

            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {

                rand = Random.Range(0, templates.endRooms.Length);
                Instantiate(templates.endRooms[rand], transform.position, templates.endRooms[rand].transform.rotation, Grid.transform);
                Destroy(other.gameObject);

            }
            spawned = true;
        }
    }
    */
}
