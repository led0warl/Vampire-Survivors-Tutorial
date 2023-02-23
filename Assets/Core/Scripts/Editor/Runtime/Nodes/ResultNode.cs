using UnityEngine;

namespace Core.Nodes
{
    public class ReslutNode : CodeFunctionNode
    {
        [HideInInspector]
        public CodeFunctionNode child;
        
        public override float value => child.value;
    }
}