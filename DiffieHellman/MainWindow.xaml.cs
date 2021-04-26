using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Numerics;

namespace DiffieHellman
{
    public partial class MainWindow : Window
    {
        private CommonData _data;

        private Person _alice;
        private Person _bob;

        public MainWindow()
        {
            InitializeComponent();

            InitCommonData();
            InitBob();
            InitAlice();
        }

        private void InitBob()
        {
            _bob = new Person(_data);
            inputB.Text = _bob._x.ToString();
            inputBobY.Text = _bob.X.ToString();
        }

        private void InitAlice()
        {
            _alice = new Person(_data);
            inputA.Text = _alice._x.ToString();
            inputAliceX.Text = _alice.X.ToString();
        }

        private void InitCommonData()
        {
            _data = new CommonData();

            inputP.Text = _data.P.ToString();
            inputQ.Text = _data.Q.ToString();
            inputG.Text = _data.G.ToString();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            InitCommonData();
            InitBob();
            InitAlice();
        }

        private void BtnExchange_Click(object sender, RoutedEventArgs e)
        {
            // Alice sends Bob value of X
            _alice.SendXToAnotherPerson(_bob);

            // Bob sends Alice value of Y
            _bob.SendXToAnotherPerson(_alice);

            inputFromAliceX.Text = _bob.Y.ToString();
            inputFromBobY.Text = _alice.Y.ToString();
        }

        private void BtnGetKey_Click(object sender, RoutedEventArgs e)
        {
            inputAliceK.Text = _alice.Key.ToString();
            inputBobK.Text = _bob.Key.ToString();
        }
    }
}
