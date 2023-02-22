using Core.Nodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName ="NodeGraph",menuName ="Core/NodeGraph")]
    public class NodeGraph : ScriptableObject
    {
        public CodeFunctionNode rootNode;
        public List<CodeFunctionNode> nodes = new List<CodeFunctionNode>();
    }
}