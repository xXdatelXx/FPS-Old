﻿using FPS.GamePlay;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CharacterMovementFactory : SerializedMonoBehaviour, ICharacterMovementFactory
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private AnimationCurve _jumpMotion;
        [SerializeField, Range(0, 100)] private float _speed;

        public ICharacterMovement Create(IReadOnlyGameTime time)
        {
            var controller = new CharacterMovementController(_controller);
            var gravitation = new CharacterGravitation(controller);
            var jump = new CharacterJump(controller, new Curve(_jumpMotion));

            return new CharacterMovement(controller, jump, gravitation, _speed);
        }
    }
}