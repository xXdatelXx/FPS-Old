﻿using Cysharp.Threading.Tasks;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class RandomBulletRay : IBulletRay
    {
        private readonly IBulletRay _ray;
        private readonly IRandom<bool> _random;

        public RandomBulletRay(IBulletRay ray, IRandom<bool> random)
        {
            _ray = ray.ThrowExceptionIfArgumentNull(nameof(ray));
            _random = random.ThrowExceptionIfArgumentNull(nameof(random));
        }

        public void Cast()
        {
            
        }

        public void Cast(Vector3 target)
        {
            if(_random.Next())
                _ray.Cast(target);
        }

        public UniTask End()
        {
            throw new System.NotImplementedException();
        }
    }
}