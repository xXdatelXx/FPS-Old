﻿using FPS.Model;
using NUnit.Framework;

namespace FPS.Tests
{
    public sealed class CharacterOrganTest
    {
        [Test]
        public void OrganWorkCorrectly()
        {
            var health = new Health(2);
            var organ = new CharacterOrgan();
            organ.Construct(health, 2);
            
            organ.TakeDamage(1);
            
            Assert.AreEqual(health.Died, true);
        }
    }
}