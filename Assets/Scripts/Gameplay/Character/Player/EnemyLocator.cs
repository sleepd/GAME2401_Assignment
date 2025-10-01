using UnityEngine;
public class EnemyLocator
{
    PlayerController player;
    LayerMask enemyLayer;
    public EnemyLocator(PlayerController player)
    {
        this.player = player;
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    public Transform FindNearestEnemy(float SearchRadius)
    {
        Collider[] hits = Physics.OverlapSphere(player.transform.position, SearchRadius, enemyLayer);
        float minDist = float.MaxValue;
        Transform nearest = null;
        foreach (var hit in hits)
        {
            float dist = Vector3.Distance(player.transform.position, hit.transform.position);
            if (dist < 0.1f)
            {
                nearest = hit.transform;
                break;
            }
            if (dist < minDist)
                {
                    minDist = dist;
                    nearest = hit.transform;
                }
        }
        return nearest;
    }
}