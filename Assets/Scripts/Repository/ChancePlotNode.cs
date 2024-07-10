using Repository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(ChancePlotNode))]
public class ChancePlotNode : PlotNode
{
    [SerializeField][Range(0, 100)] private float chanceFor1;
    [SerializeField][TextArea] private string outputText2;

    public override string OutputText =>
        Random.Range(0f, 100f) < chanceFor1 ? outputText : outputText2;
}
