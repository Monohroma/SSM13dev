using UnityEngine;
public interface IAttacking
{
    enum WeaponType { Melee, Ranged }
    int AttackNPC();
    int findClosest();
}
