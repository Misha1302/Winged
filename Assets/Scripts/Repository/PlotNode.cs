namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;

    public abstract class PlotNode : ScriptableObject
    {
        [SerializeField][TextArea] protected string outputText;
        [SerializeField] private List<PlotNode> nextNodes;


        [NonSerialized] public bool Used;

        private Lazy<List<Answer>> _answers;

        protected PlotNode()
        {
            _answers = new Lazy<List<Answer>>(() => nextNodes.Select(x => new Answer(PlotNodeToName(x), x)).ToList());
        }

        public IReadOnlyList<Answer> Answers => _answers.Value;
        public virtual string OutputText => outputText;


        private string PlotNodeToName(PlotNode node)
        {
            return node != null ? node.name[(node.name.IndexOf(' ') + 1)..] : string.Empty;
        }
    }
}