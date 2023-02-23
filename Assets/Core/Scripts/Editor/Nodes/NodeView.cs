using Core.Nodes;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace Core.Editor.Nodes
{
    public class NodeView : Node
    {
        public CodeFunctionNode node;
        public List<Port> inputs = new List<Port>();
        public Port output;

        protected Port CreateOutputPort(string portName = "", Port.Capacity capacity = Port.Capacity.Single)
        {
            Port outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, capacity, typeof(float));
            outputPort.portName = portName;
            outputContainer.Add(outputPort);
            RefreshPorts();
            return outputPort;
        }

        protected Port CreateInputPort(string portName="",Port.Capacity capacity = Port.Capacity.Single)
        {
            Port inputPort = InstantiatePort(Orientation.Horizontal,Direction.Input, capacity, typeof(float));
            inputPort.portName = portName;
            inputContainer.Add(inputPort);
            RefreshPorts();
            return inputPort; 
        }

    }
}