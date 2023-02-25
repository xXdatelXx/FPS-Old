﻿using Source.Runtime.Data.Weapon;
using Source.Runtime.Input;
using Source.Runtime.Models.Player.Weapon;
using Source.Runtime.Models.Player.Weapon.Interfaces;
using Source.Runtime.Models.Weapons.Bullet;
using Source.Runtime.Models.Weapons.Bullet.Factory;
using Source.Runtime.Models.Weapons.Kind;
using Source.Runtime.Models.Weapons.Kind.Interfaces;
using Source.Runtime.Models.Weapons.Magazine;
using Source.Runtime.Models.Weapons.Views;
using Source.Runtime.Tools.Components.UI;
using Source.Runtime.Tools.Math;
using Source.Runtime.Tools.Timer;
using Source.Runtime.Views.Text;
using UnityEngine;

namespace Source.Runtime.Models.Factory.Character.Weapon
{
    public sealed class PlayerWeaponFactory : MonoBehaviour, IPlayerWeaponFactory
    {
        [SerializeField] private RaySpawnPoint _bulletSpawnPoint;
        [SerializeField] private FullWeaponData _weaponData;
        [SerializeField] private WeaponAnimator _animator;
        [SerializeField] private UnityText _bulletsText;
        [SerializeField] private AnimationCurve _damageCurve;

        public IPlayerWithWeapon Create()
        {
            var input = new PlayerWeaponInput();
            var weapon = CreateWeapon();

            var playerWeapon = new PlayerWithWeapon(weapon, input);
            var playerWeaponWithMagazine = new PlayerWeaponWithMagazine(playerWeapon, weapon, input);

            return playerWeaponWithMagazine;
        }

        private IWeaponWithMagazine CreateWeapon()
        {
            var damageCoefficient = new CurveDamageCoefficient(new Curve(_damageCurve));
            var bulletsFactory = new RayBulletFactory(_bulletSpawnPoint, _weaponData.Damage, damageCoefficient);
            var magazine = new Magazine(_weaponData.Bullets);
            var view = new WeaponView(new BulletsView(new TextView(_bulletsText)), _animator);

            var weapon = new Weapons.Kind.Weapon(bulletsFactory, view);
            var weaponWithDelay = new WeaponWithDelay(weapon, new Timer(_weaponData.Delay));
            var handWeapon = new HandWeapon(weaponWithDelay, new Timer(_weaponData.Enable), view);
            var weaponWithMagazine = new WeaponWithMagazine(handWeapon, magazine, new Timer(_weaponData.Reload), view);

            return weaponWithMagazine;
        }
    }
}