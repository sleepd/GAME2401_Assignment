using UnityEngine;
public class MiniGun : ProjectileWeapon
{
    protected override void OnUse()
    {
        Transform nearest = weaponManager.player.enemyLocator.FindNearestEnemy(_attackRadius);

        Vector3 targetDir;
        if (nearest == null) targetDir = weaponManager.player.transform.forward;
        else targetDir = nearest.position - weaponManager.player.transform.position;

        if (targetDir.sqrMagnitude < Mathf.Epsilon)
        {
            targetDir = transform.forward;
        }
        SpawnProjectile(targetDir);
    }
}