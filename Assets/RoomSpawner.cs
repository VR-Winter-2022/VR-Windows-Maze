using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 North
    //2 South
    //3 East
    //4 West
        
    private RoomTemplates templates;
    private int rand;
    private bool spawned;

void Start(){
    // Debug.Log("Start");
    templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    spawned = false;
    Invoke("Spawn", 0.1f);
}

    void Spawn(){
        // Debug.Log("Spawn, od " + openingDirection);
        if(spawned == false){

            if(openingDirection == 1){
                rand = Random.Range(0, templates.northRooms.Length);
                // Debug.Log("N Rand " + rand);
                Instantiate(templates.northRooms[rand],transform.position,templates.northRooms[rand].transform.rotation);
            }
            else if(openingDirection ==2){
                rand = Random.Range(0, templates.southRooms.Length);
                // Debug.Log("S Rand " + rand);
                Instantiate(templates.southRooms[rand],transform.position,templates.southRooms[rand].transform.rotation);

            }else if(openingDirection ==3){
                rand = Random.Range(0, templates.eastRooms.Length);
                // Debug.Log("E Rand " + rand);
                Instantiate(templates.eastRooms[rand],transform.position,templates.eastRooms[rand].transform.rotation);

            }else if(openingDirection ==4){
                rand = Random.Range(0, templates.westRooms.Length);
                // Debug.Log("W Rand " + rand);
                Instantiate(templates.westRooms[rand],transform.position,templates.westRooms[rand].transform.rotation);

            }
            spawned = true;
        }

    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("SpawnPoint") || other.CompareTag("Boundary") || other.CompareTag("WallCheck")){
            Debug.Log(other.tag);
            Destroy(gameObject);
        }
    }
}