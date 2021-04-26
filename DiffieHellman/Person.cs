using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellman
{
    public class Person
    {
        public CommonData Data { get; private set; }
        public BigInteger X { get; private set; }

        // received from another person
        public BigInteger Y { get; set; }

        public BigInteger _x;
        public BigInteger Key => DiffHellman.GetK(Y, _x, Data.P);

        public Person(CommonData data)
        {
            Data = data;

            _x = DiffHellman.GenerateA(Data.P);
            X = DiffHellman.GetX(Data.G, _x, Data.Q, Data.P);
        }

        public void SendXToAnotherPerson(Person person) => person.Y = X;
    }
}
