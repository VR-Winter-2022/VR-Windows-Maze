using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    public bool spawned;
    //1 North
    //2 South
    //3 East
    //4 West
        
    private RoomTemplates templates;
    private int rand;
    public float waitTime = 4f;

void Start(){
    //destroys spawners after 4 seconds for object clearing
    Destroy(gameObject, waitTime);

    //get the rooms from prefab
    templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    spawned = false;

    //start spawning after short wait
    Invoke("Spawn", 0.1f);
}

//spawnpoints have given opening directions
//when they spawn they go and select a tile
//for each appropriate spawn dirction from
//a bag in RoomTemplates.cs, and those rooms
//attempt to spawn
    void Spawn(){
        if(spawned == false){

            if(openingDirection == 1){
                rand = Random.Range(0, templates.northRooms.Length);
                Instantiate(templates.northRooms[rand],transform.position,templates.northRooms[rand].transform.rotation);
            }
            else if(openingDirection ==2){
                rand = Random.Range(0, templates.southRooms.Length);
                Instantiate(templates.southRooms[rand],transform.position,templates.southRooms[rand].transform.rotation);

            }else if(openingDirection ==3){
                rand = Random.Range(0, templates.eastRooms.Length);
                Instantiate(templates.eastRooms[rand],transform.position,templates.eastRooms[rand].transform.rotation);

            }else if(openingDirection ==4){
                rand = Random.Range(0, templates.westRooms.Length);
                Instantiate(templates.westRooms[rand],transform.position,templates.westRooms[rand].transform.rotation);

            }
            spawned = true;
        }
        else  {
                Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z+" made w room");
        }

    }
    //self destruct if landing on a pre-existing spawner
    void OnTriggerEnter(Collider other){
        if((other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned==true)|| other.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }

//helpful debugging func for getting spawn's parent tile
    // void debugHelper(char letter){
    //     // Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z +", Spawn #" + count + ": "+ letter +" Rand " + rand);
    //     Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z);
    // }

}
