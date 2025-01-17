﻿using System;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(Collider))]
    [DisallowMultipleComponent]
    public sealed class CharacterOrgan : MonoBehaviour, ICharacterOrgan
    {
        private IHealth _health;
        private float _multiplier;

        public void Construct(IHealth health, float multiplier)
        {
            _health = health.ThrowExceptionIfArgumentNull(nameof(health));
            _multiplier = multiplier.ThrowExceptionIfValueSubZero(nameof(multiplier));
        }

        public bool Died => _health.Died;
        public float Points => _health.Points;

        public void TakeDamage(float damage)
        {
            if (Died)
                throw new InvalidOperationException(nameof(TakeDamage));

            damage.ThrowExceptionIfValueSubZero(nameof(damage));

            _health.TakeDamage(damage * _multiplier);
        }
    }
}