﻿using Source.Runtime.Models.GameObjects;
using Source.Runtime.Tools.Extensions;
using Source.Runtime.Views.Text;

namespace Source.Runtime.Model.Health.Views
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IGameObject _character;
        private readonly ITextView _healthText;

        public CharacterHealthView(ITextView healthText, IGameObject character)
        {
            _healthText = healthText.ThrowExceptionIfArgumentNull(nameof(healthText));
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));
        }

        public void Damage(float health) => 
            _healthText.Visualize(health);

        public void Die() => 
            _character.Destroy();
    }
}