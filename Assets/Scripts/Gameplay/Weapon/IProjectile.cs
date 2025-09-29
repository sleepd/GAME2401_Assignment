using UnityEngine;
using UnityEngine.Pool;

public interface IProjectile
{
    ObjectPool<IProjectile> pool { get; set; }
    IWeapon weapon { get; set; }
    GameObject gameObject { get; }
}
