using UnityEngine;
public class MiniGun : WeaponBase
{
    [SerializeField] GameObject bullet;
    [SerializeField] float attackRadius;
    protected override void OnUse()
    {
        Transform nearest = weaponManager.player.enemyLocator.FindNearestEnemy(attackRadius);

        Vector3 targetDir;
        if (nearest == null) targetDir = weaponManager.player.transform.forward;
        else targetDir = nearest.position - weaponManager.player.transform.position;

        if (targetDir.sqrMagnitude < Mathf.Epsilon)
        {
            targetDir = transform.forward;
        }

        Quaternion rotation = Quaternion.LookRotation(targetDir.normalized, Vector3.up);
        Instantiate(bullet, transform.position, rotation);
    }
}
