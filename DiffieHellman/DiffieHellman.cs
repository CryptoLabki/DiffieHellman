using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DiffieHellman
{
    class DiffieHellman
    {
        public static BigInteger GetX (BigInteger g, BigInteger x, BigInteger q, BigInteger p)
        {
            var temp = x % q;
            var X = MathUtils.ModExp(g, temp, p);
            return X;
        }

        public static BigInteger GetK (BigInteger X, BigInteger a, BigInteger p)
        {
            var K = MathUtils.ModExp(X, a, p);
            return K;
        }

        public static BigInteger GenerateA (BigInteger p)
        {
            var a = RandomGenerator.GetNumber(2, p - 1);
            return a;
        }
    }
}
