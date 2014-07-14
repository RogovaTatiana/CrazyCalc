using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BionicLab11.Model;

namespace BionicLab11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResultBox.Text = res.ToString();
        }
        
        private double res;
        private int flag;
        private double result;
        public Coordinates margins = new Coordinates();
        Regex r = new Regex("\b,([0-9]+)");

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string exp = ResultBox.Text;
            if ((res==0)&&(!exp.Equals(",")))
            {
                Button b = (Button)sender;
                exp = b.Content.ToString();
            }
            else
            {
                Button b = (Button)sender;
                exp = exp + b.Content;
            }
            ResultBox.Text = exp;
            exp = r.Replace(exp, "0,$1");
            res = Convert.ToDouble(exp);
            Mix();
        }

        private void ButtonDec_Click(object sender, RoutedEventArgs e)
        {
            string exp = ResultBox.Text;
            if (res == 0)
            {
                exp = ",";
                ResultBox.Text = exp;
                res = 0;
            }
            else
            {
                if (!exp.Contains(','))
                exp = exp + ",";
                ResultBox.Text = exp;
            }
            Mix();
        }

        private void ButtonOper_Click(object sender, RoutedEventArgs e)
        {
            Eqv();
            ResultBox.Text = result.ToString();
            res = 0;
            Button b = (Button)sender;
            switch (b.Content.ToString())
            {
                case "+":
                    flag = 1;
                    break;
                case "-":
                    flag = 2;
                    break;
                case "*":
                    flag = 3;
                    break;
                case "/":
                    flag = 4;
                    break;
            }
            Mix();
        }

        private void ButtonEqv_Click(object sender, RoutedEventArgs e)
        {
            Eqv();
            res = 0;
            flag = 0;
            ResultBox.Text = result.ToString();
            result = 0;
            Mix();
        }

        private void Eqv()
        {
            switch (flag)
            {
                case 1:
                    result += res;
                    break;
                case 2:
                    result -= res;
                    break;
                case 3:
                    result = result * res;
                    break;
                case 4:
                    result = result / res;
                    break;
                default:
                    result += res;
                    break;
            }
        }

        public void Mix()
        {
            Random r = new Random();
            ThicknessAnimation[] ta = new ThicknessAnimation[16];
            int[] i = new int[16]{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

            for (int k = 0; k < i.Length; k++)
            {
                int l=r.Next(0, 16);
                if (!i.Contains(l))
                    i[k] = l;
                else
                {
                    while (i.Contains(l))
                    {
                        l = r.Next(0, 16);
                    }
                    i[k] = l;
                }
            }

            for (int j = 0; j < ta.Length; j++)
            {
                ta[j] = new ThicknessAnimation();
                ta[j].To = new Thickness(margins.Margins[i[j]].Left, margins.Margins[i[j]].Top, margins.Margins[i[j]].Right, margins.Margins[i[j]].Bottom);
            }

            Button0.BeginAnimation(Button.MarginProperty, ta[0]);
            Button1.BeginAnimation(Button.MarginProperty, ta[1]);
            Button2.BeginAnimation(Button.MarginProperty, ta[2]);
            Button3.BeginAnimation(Button.MarginProperty, ta[3]);
            Button4.BeginAnimation(Button.MarginProperty, ta[4]);
            Button5.BeginAnimation(Button.MarginProperty, ta[5]);
            Button6.BeginAnimation(Button.MarginProperty, ta[6]);
            Button7.BeginAnimation(Button.MarginProperty, ta[7]);
            Button8.BeginAnimation(Button.MarginProperty, ta[8]);
            Button9.BeginAnimation(Button.MarginProperty, ta[9]);
            ButtonDec.BeginAnimation(Button.MarginProperty, ta[10]);
            ButtonDev.BeginAnimation(Button.MarginProperty, ta[11]);
            ButtonMult.BeginAnimation(Button.MarginProperty, ta[12]);
            ButtonMin.BeginAnimation(Button.MarginProperty, ta[13]);
            ButtonEqv.BeginAnimation(Button.MarginProperty, ta[14]);
            ButtonAdd.BeginAnimation(Button.MarginProperty, ta[15]);
        }


    }
}
