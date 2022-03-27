using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    [Header("Objects To Drop")]
    public List<GameObject> Drops;
    
    public void Drop(){
        for (int i = 0; i < Drops.Count; i++)
        {
            Instantiate(Drops[i], transform.position, Quaternion.identity);
        }
    }
    
}
