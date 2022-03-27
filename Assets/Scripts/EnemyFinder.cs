using Unity.Mathematics;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    // This script is used to find enemies in certain range and return their position in a function
    public Vector3 range;
    public float centerZ;
    public float radius = 5f;
    public LayerMask enemyLayer;
    
    public Vector3 FindEnemy()
    {
        //Collider[] enemies = Physics.OverlapSphere(transform.position, radius, enemyLayer);
        Collider[] enemies = Physics.OverlapBox(transform.position + Vector3.forward * centerZ, range,quaternion.identity, enemyLayer);
        if (enemies != null)
        {
            if (enemies.Length != 0)
            {
                return enemies[0].transform.position;
            }
        }
        return Vector3.zero;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.forward * centerZ, range);
    }
}
