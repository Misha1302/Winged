namespace Repository
{
    public class Answer
    {
        public readonly string Text;
        public readonly PlotNode NextPlotNode;

        public Answer(string text, PlotNode nextPlotNode)
        {
            Text = text;
            NextPlotNode = nextPlotNode;
        }
    }
}