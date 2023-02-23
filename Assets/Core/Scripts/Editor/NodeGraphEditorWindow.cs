using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Callbacks;
using System;

namespace Core.Editor
{
    public class NodeGraphEditorWindow : EditorWindow
    {
        private NodeGraph m_NodeGraph;
        private NodeGraphView m_NodeGraphView;
        private VisualElement m_LeftPanel;
        public static void ShowWindow(NodeGraph nodeGraph)
        {
            NodeGraphEditorWindow window = GetWindow<NodeGraphEditorWindow>();
            window.SelectNodeGraph(nodeGraph);
            window.minSize = new Vector2(800, 600);
            window.titleContent = new GUIContent("NodeGraph");
        }

        [OnOpenAsset(1)]
        public static bool OnOpenAssert(int instanceID, int line)
        {
            if (EditorUtility.InstanceIDToObject(instanceID) is NodeGraph nodeGraph)
            {
                ShowWindow(nodeGraph);
                return true;
            }
            return false;
        }

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Core/Scripts/Editor/NodeGraphEditorWindow.uxml");
            visualTree.CloneTree(root);
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Core/Scripts/Editor/NodeGraphEditorWindow.uss");
            root.styleSheets.Add(styleSheet);

            m_LeftPanel = root.Q("left-panel");
            m_NodeGraphView = root.Q<NodeGraphView>();
        }

        private void OnSelectionChange()
        {
            if (Selection.activeObject is NodeGraph nodeGraph)
            {
                SelectNodeGraph(nodeGraph);
            }
        }

        private void SelectNodeGraph(NodeGraph nodeGraph)
        {
            m_NodeGraph = nodeGraph;
            m_NodeGraphView.PopulateView(m_NodeGraph);
        }
    }
}