using DesafioLevelUp.Models;
using DesafioLevelUp.Models.Base;
using System;
using System.Collections.Generic;
using System.IO;

namespace DesafioLevelUp.Utils
{
    public class Parser
    {
        private Scanner _scanner;

        private Parser(Scanner scanner)
        {
            _scanner = scanner;
        }

        private Order ParseOrder(int codigo)
        {
            _scanner.AssertTotalSize(74);
            return new Order
            {
                Id = codigo,
                Descricao = _scanner.GetString(43).TrimEnd(),
                Date = _scanner.GetDate("yyyyMMddHHmmss"),
                Value = (float)_scanner.GetReal(10),
                Status = _scanner.GetChar()
            };
        }

        private Item ParseItem(int codigo)
        {
            _scanner.AssertTotalSize(71);
            return new Item
            {
                Id = codigo,
                OrderId = (int)_scanner.GetNumeric(5),
                Description = _scanner.GetString(50).TrimEnd(),
                Value = (float)_scanner.GetReal(10)
            };
        }

        public IEnumerable<BaseEntity> Parse()
        {
            while (_scanner.NextLine())
            {
                _scanner.AssertTotalSize(1);
                int tipo = _scanner.GetChar();
                _scanner.AssertSize(5);
                int codigo = (int)_scanner.GetNumeric(5);
                if (tipo == '1')
                {
                    yield return ParseOrder(codigo);
                }
                else if (tipo == '2')
                {
                    yield return ParseItem(codigo);
                }
            }
            _scanner.Dispose();
            _scanner = null;
        }

        public static Parser FromFile(string file)
        {
            return new Parser(new Scanner(new StreamReader(file)));
        }



    }
}
