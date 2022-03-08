using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Boundary")){
            Destroy(other.gameObject);
        }
    }
}
