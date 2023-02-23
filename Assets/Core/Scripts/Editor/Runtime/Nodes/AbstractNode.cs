using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Nodes
{
    public abstract class AbstractNode : ScriptableObject
    {
        [HideInInspector] public Vector2 position;
        [HideInInspector] public string guid;
    }
}