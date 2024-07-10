using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class AnswerButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text answer;
        [SerializeField] private Image frontImage;
        [SerializeField] private Button button;

        public Button.ButtonClickedEvent OnClick => button.onClick;

        public void Init(string answerText, Color frontColor)
        {
            answer.text = answerText;
            frontImage.color = frontColor;
        }
    }
}