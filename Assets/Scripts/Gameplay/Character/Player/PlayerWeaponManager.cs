using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager
{
    private List<IWeapon> weapons;
    public PlayerController player { get; private set; }

    public PlayerWeaponManager(PlayerController player)
    {
        weapons = new();
        this.player = player;
    }

    public void AddWeapon(IWeapon weapon)
    {
        if (weapon == null) return;
        weapons.Add(weapon);
        weapon.SetWeaponManager(this);
    }

    public void UseWeapon()
    {
        foreach (IWeapon weapon in weapons)
        {
            weapon.Use();
        }
    }
}