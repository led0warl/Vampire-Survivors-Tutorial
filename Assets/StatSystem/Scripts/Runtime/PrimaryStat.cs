﻿using SaveSystem.Runtime;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StatSystem.Tests")]
namespace StatSystem
{
    public class PrimaryStat : Stat, ISavable
    {
        private int m_BaseValue;
        public override int baseValue => m_BaseValue;
        
        public PrimaryStat(StatDefinition definition) : base(definition)
        {
            
        }

        public override void Initialize()
        {
            m_BaseValue = definition.baseValue;
            base.Initialize();

        }

        internal void Add(int amount)
        {
            m_BaseValue += amount;
            CalculateValue();
        }

        internal void Subtract(int amount)
        {
            m_BaseValue -= amount;
            CalculateValue();
        }
        #region Save System

        public object data => new PrimaryStatData
        {
            baseValue = m_BaseValue,
        };

        public void Load(object data)
        {
            PrimaryStatData primaryStatData = (PrimaryStatData)data;
            m_BaseValue = primaryStatData.baseValue;
            CalculateValue();
        }


        [Serializable]
        protected class PrimaryStatData
        {
            public int baseValue;
        }

        #endregion

    }
}