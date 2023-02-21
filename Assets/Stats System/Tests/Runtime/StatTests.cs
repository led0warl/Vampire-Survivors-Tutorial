using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace StatSystem.Tests
{
    public class StatTests
    {

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            EditorSceneManager.LoadSceneInPlayMode("Assets/Stats System/Tests/Scences/TestStat.unity",new LoadSceneParameters(LoadSceneMode.Single));
        }

        [UnityTest]
        public IEnumerator Stat_WhenModfierApplied_ChangesValue()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            Stat physicalAttack = statController.Stats["PhysicalAttack"];
            Assert.AreEqual(0, physicalAttack.value);
            physicalAttack.AddModifier(new StatModifier
            {
                magnitude = 5,
                type = ModifierOperationType.Additive
            });
            Assert.AreEqual(5,physicalAttack.value);

        }

        [UnityTest]
        public IEnumerator Stat_WhenModifierApplied_DoesNotExceedCap()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            Stat attackSpeed = statController.Stats["AttackSpeed"];
            Assert.AreEqual(1,attackSpeed.value);
            attackSpeed.AddModifier(new StatModifier
            {
                magnitude = 5,
                type = ModifierOperationType.Additive
            });
            Assert.AreEqual(3,attackSpeed.value);
        }
    }
}