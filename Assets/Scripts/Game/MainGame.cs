namespace Game
{
    using System.Linq;
    using Repository;
    using UnityEngine;
    using View;

    public class MainGame : MonoBehaviour
    {
        [SerializeField] private TextWindow textWindow;
        [SerializeField] private AnswerButtons answerButtons;

        private readonly AnswerRepository _answerRepository = new();

        private PlotNode _curNode;


        private void Start()
        {
            _curNode = _answerRepository.Nodes[0];
            Show();
        }

        private void Show()
        {
            textWindow.Print(_curNode.OutputText);
            answerButtons.ShowAnswers(_curNode.Answers, Chosen);
            return;

            void Chosen(int answerIndex)
            {
                _curNode = _curNode.Answers[answerIndex].NextPlotNode;
                Show();
            }
        }
    }
}