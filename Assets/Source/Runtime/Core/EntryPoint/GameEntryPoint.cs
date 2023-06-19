using FPS.Data;
using FPS.Factories;
using UnityEngine;

namespace FPS.Core
{
    [DisallowMultipleComponent]
    public sealed class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private PlayerWeaponCollectionFactory _playerWeaponFactory;

        private void Start()
        {
            var gameEngine = new GameEngine(new Data.Factories(_playerFactory, _playerWeaponFactory));
            new Game(gameEngine).Play();
        }
    }
}