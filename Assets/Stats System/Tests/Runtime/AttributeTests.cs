using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace StatSystem.Tests
{
    public class AttributeTests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            EditorSceneManager.LoadSceneInPlayMode("Assets/Stats System/Tests/Scences/TestStat.unity", new LoadSceneParameters(LoadSceneMode.Single));
        }

        [UnityTest]
        public IEnumerator Attribute_WhenModifierApplied_DoesNotExceedMaxValue()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            Attribute health = statController.Stats["Health"] as Attribute;
            Assert.AreEqual(100, health.currentValue);
            Assert.AreEqual(100, health.value);
            health.ApplyModifier(new StatModifier
            {
                magnitude = 20,
                type = ModifierOperationType.Additive
            });
            Assert.AreEqual(100, health.currentValue); // ค่าที่คาดว่าจะได้ คือ 100 เพราะจะค่าจะไม่ เกิน max ที่100
        }

        [UnityTest]
        [CanBeNull]
        public IEnumerator Attribute_WhenModifierApplied_DoesNotGoBelowZero()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            Attribute health = statController.Stats["Health"] as Attribute;
            Assert.AreEqual(100, health.currentValue);
            health.ApplyModifier(new StatModifier
            {
                magnitude = -150,
                type = ModifierOperationType.Additive
            });
            Assert.AreEqual(0, health.currentValue); // ค่าที่คาดว่าจะได้ 0 เพราะ 100 -150 = -50 แต่ Mathf.Clamp ไม่ให้ติดลบเกิน 0
        }
    }
}