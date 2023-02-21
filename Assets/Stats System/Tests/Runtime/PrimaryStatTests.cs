﻿


using NUnit.Framework;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace StatSystem.Tests
{
    public class PrimaryStatTests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            EditorSceneManager.LoadSceneInPlayMode("Assets/Stats System/Tests/Scences/TestStat.unity", new LoadSceneParameters(LoadSceneMode.Single));
        }

        [UnityTest]
        public IEnumerator Stat_WhenAddCalled_ChangesBaseValue()
        {
            yield return null;
            StatController statController = GameObject.FindObjectOfType<StatController>();
            PrimaryStat strength = statController.stats["Strength"] as PrimaryStat;
            Assert.AreEqual(1, strength.value);
            strength.Add(1);
            Assert.AreEqual(2,strength.value);
        }
        


    }
}