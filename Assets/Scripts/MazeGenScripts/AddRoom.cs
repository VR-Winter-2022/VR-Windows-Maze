using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//exists only to add a tile clone to RoomTemplate's list of rooms
public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

}