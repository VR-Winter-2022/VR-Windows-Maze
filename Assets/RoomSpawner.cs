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

void Start(){
    // Debug.Log("Start");
    templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    spawned = false;
    Invoke("Spawn", 0.1f);
}

    void Spawn(){
        // Debug.Log(this.transform.parent.parent.parent + ", Spawn #"+ count);
        if(spawned == false){

            if(openingDirection == 1){
                rand = Random.Range(0, templates.northRooms.Length);
                // debugHelper('n');
                Instantiate(templates.northRooms[rand],transform.position,templates.northRooms[rand].transform.rotation);
                // Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z+ " made n room");
            }
            else if(openingDirection ==2){
                rand = Random.Range(0, templates.southRooms.Length);
                // debugHelper('s');
                Instantiate(templates.southRooms[rand],transform.position,templates.southRooms[rand].transform.rotation);

                // Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z+ " made s room");
            }else if(openingDirection ==3){
                rand = Random.Range(0, templates.eastRooms.Length);
                // debugHelper('e');
                Instantiate(templates.eastRooms[rand],transform.position,templates.eastRooms[rand].transform.rotation);

                // Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z+ " made e room");
            }else if(openingDirection ==4){
                rand = Random.Range(0, templates.westRooms.Length);
                // debugHelper('w');
                Instantiate(templates.westRooms[rand],transform.position,templates.westRooms[rand].transform.rotation);
                // Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z+" made w room");

            }
            spawned = true;
        }
        else  {
                Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z+" made w room");
        }

    }
    void OnTriggerEnter(Collider other){
        if((other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned==true)|| other.CompareTag("Wall")){
            //Debug.Log(other.tag);
            debugHelper('x');
            Destroy(gameObject);
        }
    }
    void debugHelper(char letter){
        // Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z +", Spawn #" + count + ": "+ letter +" Rand " + rand);
        Debug.Log(this.transform.parent.parent.parent + " at "+ this.transform.position.x + ","+this.transform.position.z);
    }

}
