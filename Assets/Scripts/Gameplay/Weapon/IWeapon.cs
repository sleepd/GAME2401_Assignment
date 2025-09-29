using System;

public interface IWeapon
{
    void Use();
    void SetWeaponManager(PlayerWeaponManager manager);
    bool CanUse { get; }
    event Action OnUsed;
    int damage { get; }
}
