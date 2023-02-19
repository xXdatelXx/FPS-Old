﻿using Source.Runtime.Data.Weapon.Interfaces;
using UnityEngine;

namespace Source.Runtime.Data.Weapon
{
    [CreateAssetMenu(menuName = nameof(FullWeaponData))]
    public sealed class FullWeaponData : ScriptableObject, IFullWeaponData
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Reload { get; private set; }
        [field: SerializeField] public int Bullets { get; private set; }
        [field: SerializeField] public float Delay { get; private set; }
        [field: SerializeField] public float Enable { get; private set; }
    }
}