namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class AnswerRepository
    {
        private readonly Lazy<List<PlotNode>> _lazyNodes = new(() => Resources.LoadAll<PlotNode>("Nodes").ToList());

        private List<PlotNode> PrivateNodes => _lazyNodes.Value;

        public IReadOnlyList<PlotNode> Nodes => PrivateNodes;
    }
}
