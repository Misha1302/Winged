namespace View
{
    public class CharsPrintTime
    {
        private readonly float _anyCharPrintTime;
        private readonly float _newLinePrintTime;
        private readonly float _afterDotPrintTime;

        private char _prevChar;

        public CharsPrintTime(float anyCharPrintTime, float newLinePrintTime, float afterDotPrintTime)
        {
            _anyCharPrintTime = anyCharPrintTime;
            _newLinePrintTime = newLinePrintTime;
            _afterDotPrintTime = afterDotPrintTime;
        }

        public float TimeToWait(char ch)
        {
            var time =
                _prevChar == '.'
                    ? _afterDotPrintTime
                    : ch == '\n'
                        ? _newLinePrintTime
                        : _anyCharPrintTime;

            _prevChar = ch;

            return time;
        }
    }
}