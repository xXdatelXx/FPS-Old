﻿using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletParticle : IBulletParticle
    {
        private readonly ParticleSystem _particleSystem;

        public BulletParticle(ParticleSystem particleSystem) =>
            _particleSystem = particleSystem.ThrowExceptionIfArgumentNull(nameof(particleSystem));

        public void Play() =>
            _particleSystem.Play(true);

        public void Stop() =>
            _particleSystem.Stop();
    }
}