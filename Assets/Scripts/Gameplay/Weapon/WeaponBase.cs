using System;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public float cooldown = 1f;
    [SerializeField] protected int _damage;
    public int damage { get => _damage; }
    protected PlayerWeaponManager weaponManager;
    protected float lastUseTime = -999f;
    public bool CanUse => Time.time - lastUseTime >= cooldown;

    public event Action OnUsed;

    public void Use()
    {
        if (!CanUse) return;
        lastUseTime = Time.time;
        OnUse();
        OnUsed?.Invoke();
    }

    public void SetWeaponManager(PlayerWeaponManager manager)
    {
        weaponManager = manager;
    }

    protected abstract void OnUse();
}