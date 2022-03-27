using System;
using UnityEngine;

public class Drop : MonoBehaviour 
{
    public enum DropType {Gem, Gold};
    public DropType drop;
    public float amount;

    private void OnTriggerStay(Collider other) {
        if (!other.gameObject.CompareTag("Player")) return;

        //Move object to player
        transform.position = Vector3.Lerp(transform.position, other.transform.position, .5f);
        
        if (Vector3.Distance(transform.position, other.transform.position) <= .5f)
        {   
            switch (drop)
            {
                case DropType.Gem:
                    var levelMng = other.gameObject.GetComponent<levelManager>();
                    if (levelMng == null) return;
                    Debug.Log(amount + " xp given");
                    levelMng.GiveXP(amount);
                    break;

                case DropType.Gold:
                    //Get gold holder
                    //Check if not null
                    //Give gold
                    Debug.Log(amount + " gold given");
                    break;
            }

            Destroy(gameObject);
        }
    }       

    public void DropFunc(){
        
    }
    
}
