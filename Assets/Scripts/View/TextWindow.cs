namespace View
{
    using System.Collections;
    using TMPro;
    using UnityEngine;

    public class TextWindow : MonoBehaviour
    {
        [SerializeField] private TMP_Text tmpText;
        private IEnumerator _enumeratorPrintSlow;

        public void Print(string source)
        {
            if (_enumeratorPrintSlow != null)
                while (_enumeratorPrintSlow.MoveNext()) { }

            _enumeratorPrintSlow = PrintSlow(source, new CharsPrintTime(0.05f, 0.25f, 0.25f));
            StartCoroutine(_enumeratorPrintSlow);
        }

        private IEnumerator PrintSlow(string source, CharsPrintTime charsPrintTime)
        {
            foreach (var ch in source)
            {
                tmpText.text += ch;
                yield return new WaitForSeconds(charsPrintTime.TimeToWait(ch));
            }

            tmpText.text += "\n\n";
        }
    }
}