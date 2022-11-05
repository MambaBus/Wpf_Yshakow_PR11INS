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
using System.Windows.Shapes;

namespace Wpf_Yshakow_PR11INS
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();

            int N = 10;
            try
            {
                N = Convert.ToInt32(FigureCount.Text);
            }
            catch (Exception ee)
            {
                this.Title = "Только целое число!";
            }
            GenerteShapes(N);
        }

        private void GenerteShapes(int N)
        {
            Random rndButton = new Random(DateTime.Now.Millisecond);
            Random rndStyle = new Random(DateTime.Now.Millisecond);
            Random rndPosition = new Random(DateTime.Now.Millisecond);
            Random rndSize = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < N; i++)
            {
                Button button;
                int shapeType = rndButton.Next(0, 2);
                button = new Button();


                int b1Style = rndStyle.Next(0, 4) + 1;
                String styleName = "style" + b1Style.ToString();
                Style b2Style = (Style)this.FindResource(styleName);
                button.Style = b2Style;

                button.Width = rndSize.Next(15, 250);
                button.Height = rndSize.Next(20, 200);

                MainCanvas.Children.Add(button);
                Canvas.SetLeft(button, rndPosition.Next(15, 700));
                Canvas.SetTop(button, rndPosition.Next(15, 300));
            }
        }

    }
}