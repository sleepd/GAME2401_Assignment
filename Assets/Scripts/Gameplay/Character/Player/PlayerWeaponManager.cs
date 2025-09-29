using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager
{
    private List<IWeapon> _weapons;
    public PlayerController player { get; private set; }

    public PlayerWeaponManager(PlayerController player)
    {
        _weapons = new();
        this.player = player;
    }

    public void AddWeapon(IWeapon weapon)
    {
        if (weapon == null) return;
        _weapons.Add(weapon);
        weapon.SetWeaponManager(this);
    }

    public void UseWeapon()
    {
        foreach (IWeapon weapon in _weapons)
        {
            weapon.Use();
        }
    }
}