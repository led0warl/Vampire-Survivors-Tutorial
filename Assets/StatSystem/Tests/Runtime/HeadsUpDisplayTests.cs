using LevelSystem;
using NUnit.Framework;
using StatSystem.UI;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

namespace StatSystem.Tests
{
    public class HeadsUpDisplay
    {
        [OneTimeSetUp]
        public void OnTimeSetup()
        {
            EditorSceneManager.LoadSceneInPlayMode("Assets/StatSystem/Tests/Scenes/Test.unity", new LoadSceneParameters(LoadSceneMode.Single));
        }

        [UnityTest]
        public IEnumerator HeadsUpDisplayUI_WhenLevelUp_UpdateText()
        {
            yield return null;
            PlayerStatController playerStatController = GameObject.FindObjectOfType<PlayerStatController>();
            ILevelable levelable = playerStatController.GetComponent<ILevelable>();
            HeadsUpDisplayUI headsUpDisplayUI = GameObject.FindObjectOfType<HeadsUpDisplayUI>();
            UIDocument uIDocument = headsUpDisplayUI.GetComponent<UIDocument>();
            Label level = uIDocument.rootVisualElement.Q<Label>("level");
            Assert.AreEqual("1", level.text);
            levelable.currentExperience += 100;
            Assert.AreEqual("2", level.text);
        }

        [UnityTest]
        public IEnumerator HeadsUpDisplayUI_WhenGainExperience_UpdateExperienceBar()
        {
            yield return null;
            PlayerStatController playerStatController = GameObject.FindObjectOfType<PlayerStatController>();
            ILevelable levelable = playerStatController.GetComponent<ILevelable>();
            HeadsUpDisplayUI headsUpDisplayUI = GameObject.FindObjectOfType<HeadsUpDisplayUI>();
            UIDocument uiDocument = headsUpDisplayUI.GetComponent<UIDocument>();
            ProgressBar experienceBar = uiDocument.rootVisualElement.Q<ProgressBar>("experience");
            Assert.AreEqual(0,experienceBar.value);
            levelable.currentExperience += 5;
            UnityEngine.Assertions.Assert.AreApproximatelyEqual(6,experienceBar.value,0.5f);

        }

        [UnityTest]
        public IEnumerator HeadsUpDisplayUI_WhenLostHealth_UpdatesManaBar()
        {
            yield return null;
            PlayerStatController playerStatController = GameObject.FindObjectOfType<PlayerStatController>();
            HeadsUpDisplayUI headsUpDisplayUI = GameObject.FindObjectOfType<HeadsUpDisplayUI>();
            UIDocument uiDocument = headsUpDisplayUI.GetComponent<UIDocument>();
            ProgressBar manaBar = uiDocument.rootVisualElement.Q<ProgressBar>("mana");
            Assert.AreEqual(100, manaBar.value);
            Attribute mana = playerStatController.stats["mana"] as Attribute;
            mana.ApplyModifier(new StatModifier()
            {
                magnitude = -10,
                type = ModifierOperationType.Additive
            });
            UnityEngine.Assertions.Assert.AreApproximatelyEqual(90, manaBar.value);
        }

        [UnityTest]
        public IEnumerator HeadsUpDisplayUI_WhenLostHealth_UpdatesHealthBar()
        {
            yield return null;
            PlayerStatController playerStatController = GameObject.FindObjectOfType<PlayerStatController>();
            HeadsUpDisplayUI  headsUpdisplayUI = GameObject.FindObjectOfType<HeadsUpDisplayUI>();
            UIDocument uiDocument = headsUpdisplayUI.GetComponent<UIDocument>();
            ProgressBar healthBar = uiDocument.rootVisualElement.Q<ProgressBar>("health");
            Assert.AreEqual(100,healthBar.value);
            Attribute health = playerStatController.stats["Health"] as Attribute;
            health.ApplyModifier(new StatModifier()
            {
                magnitude = -10,
                type = ModifierOperationType.Additive
            });
            UnityEngine.Assertions.Assert.AreApproximatelyEqual(90,healthBar.value);
        }

    }
}