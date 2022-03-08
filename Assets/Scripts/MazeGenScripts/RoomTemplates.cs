using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    //arrays of rooms to select from, 
    //counter intuitively, these represent
    //rooms that are capable of being spawned in the 
    //indicated direction
    public GameObject[] northRooms;
    public GameObject[] southRooms;
    public GameObject[] eastRooms;
    public GameObject[] westRooms;


    //list of rooms, rooms are added when they spawn
    public List<GameObject> rooms;

    public float waitTime;
    public GameObject finish;
    private bool finishSpawned = false;

    // set wait time in scene, 
    // waits x seconds, 
    // then spawns a finish block at the last generated tile
    private void Update() {
        if(waitTime <= 0 && finishSpawned == false){
            Debug.Log(this);
            Instantiate(finish, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            finishSpawned = true;
        }
        else if(finishSpawned == false){
            waitTime -= Time.deltaTime;
        }
    }
}
