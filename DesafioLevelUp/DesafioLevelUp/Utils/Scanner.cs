using System.IO;
using System;
using System.Globalization;

namespace DesafioLevelUp.Utils
{
    public class Scanner: IDisposable
    {
        private StreamReader _sr;
        private string _line;
        private int _position;
        public bool EndOfStream { get { return _sr.EndOfStream;  } }

        public Scanner(StreamReader sr)
        {
            _sr = sr;
        }

        public bool NextLine()
        {
            if (EndOfStream)
                return false;
            _line = _sr.ReadLine();
            _position = 0;
            return true;
        }

        public void AssertTotalSize(int size)
        {
            if (_line.Length < size) throw new Exception("Tamanho total da linha incorreto.");
        }

        public void AssertSize(int size)
        {
            if (_line.Length - _position < size) throw new Exception("Tamanho restante da linha incorreto");
        }

        public char GetChar() => _line[_position++];

        public string GetString(int length)
        {
            string result = _line.Substring(_position, length);
            _position += length;
            return result;
        }

        public long GetNumeric(int length)
        {
            string value = GetString(length);
            if (long.TryParse(value, out long result))
            {
                return result;
            }
            throw new Exception("Esperado um numero inteiro");
        }

        public decimal GetReal(int length)
        {
            string value = GetString(length);
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            throw new Exception("Esperado um numero real");
        }

        public DateTime GetDate(string format)
        {
            string value = GetString(format.Length);
            if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            throw new Exception("Esperado uma Data");
        }

        public void Dispose() => _sr.Dispose();
    }
}
