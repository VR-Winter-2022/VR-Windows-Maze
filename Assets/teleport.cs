using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class teleport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TeleportationArea areas = GameObject.FindGameObjectWithTag("Terrain").AddComponent<TeleportationArea>() as TeleportationArea;
        UnityEngine.GameObject[] terrains = GameObject.FindGameObjectsWithTag("Terrain");
        int countdown = 0;
        while (terrains.Length <100 &&  countdown <400){
            countdown = countdown+1;
            terrains = GameObject.FindGameObjectsWithTag("Terrain");
        }
        if (countdown >= 400){
            Debug.Log("getting terrains failed.");
        }
        Debug.Log("teleport  terrains:");
        Debug.Log(terrains.Length);
    }

    // Update is called once per frame
    async void Update()
    {
        UnityEngine.GameObject[] terrains = GameObject.FindGameObjectsWithTag("Terrain");
        for (int i = 0; i < terrains.Length; i++){
            terrains[i].AddComponent<TeleportationArea>();
        }
    }
}
