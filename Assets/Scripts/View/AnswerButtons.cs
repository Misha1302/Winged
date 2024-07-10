using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class AnswerButtons : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup group;
        [SerializeField] private AnswerButton buttonPrefab;
        [SerializeField] private Pair<Color> alternatingColors;

        private IReadOnlyList<Answer> _answers;

        public void ShowAnswers(IReadOnlyList<Answer> answers, Action<int> chosen)
        {
            _answers = answers.Where(x => !x.NextPlotNode.Used).ToList();
            DestroyAllAnswers();

            var sizeDelta = group.GetComponent<RectTransform>().sizeDelta;
            group.cellSize = new Vector2(Math.Abs(sizeDelta.x), Math.Abs(sizeDelta.y / _answers.Count));

            for (var i = 0; i < _answers.Count; i++)
                CreateButton(_answers[i].Text, chosen, i);
        }

        private void CreateButton(string answer, Action<int> chosen, int i)
        {
            var buttonIndex = i;
            var button = InstantiateButton(answer, i);
            button.OnClick.AddListener(() => Choose(chosen, buttonIndex));
        }

        private AnswerButton InstantiateButton(string answer, int i)
        {
            var button = Instantiate(buttonPrefab, group.transform);
            button.Init(answer, alternatingColors[i % 2]);
            return button;
        }

        private void Choose(Action<int> chosen, int buttonIndex)
        {
            _answers[buttonIndex].NextPlotNode.Used = true;
            DestroyAllAnswers();
            chosen?.Invoke(buttonIndex);
        }

        private void DestroyAllAnswers()
        {
            foreach (var child in group.GetComponentsInChildren<Transform>())
            {
                if (child == null) continue;
                if (child == transform) continue;

#if UNITY_EDITOR
                if (EditorApplication.isPlaying)
                    Destroy(child.gameObject);
                else DestroyImmediate(child.gameObject);
#else
                Destroy(child.gameObject);
#endif
            }
        }
    }
}