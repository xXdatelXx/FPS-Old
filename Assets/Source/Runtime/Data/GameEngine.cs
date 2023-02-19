﻿using Source.Runtime.CompositeRoot.Weapons;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.CompositeRoot
{
    public class GameEngine : IGameEngine
    {
        public GameEngine(IPlayerFactory playerFactory, IPlayerWeaponCollectionFactory playerWeaponFactory)
        {
            PlayerFactory = playerFactory.ThrowExceptionIfArgumentNull(nameof(PlayerFactory));
            PlayerWeaponFactory = playerWeaponFactory.ThrowExceptionIfArgumentNull(nameof(playerWeaponFactory));
        }

        public IPlayerFactory PlayerFactory { get; }
        public IPlayerWeaponCollectionFactory PlayerWeaponFactory { get; }
    }
}