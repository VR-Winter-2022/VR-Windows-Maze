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
    private async void Update() {
        if(waitTime <= 0 && finishSpawned == false){
            Debug.Log(this);
            Instantiate(finish, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            finishSpawned = true;
            //GameObject[] objs = GameObject.FindGameObjectsWithTag("Terrain");
            //for (int i = 0; i < objs.Length; i++){
             //   objs[i].AddComponent<UnityEngine.XR.Interaction.Toolkit.TeleportationAnchor>();
           // }

            float goblin_x = Random.Range(-82, 83) + 0.5f;
            float goblin_z = Random.Range(-72, 80) + 0.5f;
            GameObject.FindGameObjectWithTag("Enemy").transform.position = new Vector3(goblin_x,0,goblin_z);
            Destroy(this);


        }
        else if(finishSpawned == false){
            waitTime -= Time.deltaTime;
        }
    }
}
