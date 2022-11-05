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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
            Random rndShapeType = new Random(DateTime.Now.Millisecond);
            Random rndStyle = new Random(DateTime.Now.Second);
            Random rndPosition = new Random(DateTime.Now.Minute);
            Random rndSize = new Random(DateTime.Now.Minute);

            for (int i = 0; i < N; i++)
            {
                Shape currentShape;
                int shapeType = rndShapeType.Next(0, 2);
                if (shapeType == 0)
                    currentShape = new Ellipse();
                else
                    currentShape = new Rectangle();

                int shareStyle = rndStyle.Next(0, 3) + 1;
                String styleName = "style" + shareStyle.ToString();
                Style currentStyle = (Style)this.FindResource(styleName);
                currentShape.Style = currentStyle;

                currentShape.Width = rndSize.Next(10, 200);
                currentShape.Height = rndSize.Next(10, 100);

                MainCanvas.Children.Add(currentShape);
                Canvas.SetLeft(currentShape, rndPosition.Next(5, 750));
                Canvas.SetTop(currentShape, rndPosition.Next(5, 350));
            }
        }

    }
}