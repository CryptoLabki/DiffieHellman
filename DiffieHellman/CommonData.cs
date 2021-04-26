using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellman
{
    public class CommonData
    {
        public BigInteger P { get; private set; }
        public BigInteger Q { get; private set; }
        public BigInteger G { get; private set; }

        private int _n = 0;

        public CommonData()
        {
            Q = RandomGenerator.GetPrimeNumber(256);

            do
            {
                _n += 2;
                P = _n * Q + 1;
            }
            while (PrimeTester.FullTest(P) == false);

            do
            {
                var a = RandomGenerator.GetNumber(2, P - 1);
                G = MathUtils.ModExp(a, _n, P);
            }
            while (G == 1);
        }
    }
}
