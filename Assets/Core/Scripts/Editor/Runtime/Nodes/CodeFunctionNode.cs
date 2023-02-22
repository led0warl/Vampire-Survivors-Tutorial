using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Nodes
{
    public abstract class CodeFunctionNode : AbstractNode
    {
       public abstract float value { get; }
    }
}