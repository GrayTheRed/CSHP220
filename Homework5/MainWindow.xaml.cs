using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Turn = 1;
        public List<Entry> Entries;

        public MainWindow()
        {
            Entries = new List<Entry>();
            InitializeComponent();
            uxTurn.Text = "X's turn";
        }

        public void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            var state = this.WindowState;
            MainWindow mw = new MainWindow();
            mw.WindowState = state;
            mw.Show();
            Close();
        }

        public void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string tag = b.Tag.ToString();
            int col = Int32.Parse(tag[2].ToString());
            int row = Int32.Parse(tag[0].ToString());
            Entry entry = new Entry();
            entry.Row = row;
            entry.Column = col;

            if (Turn % 2 != 0)
            {
                b.Content = "X";
                entry.Mark = 'X';
                uxTurn.Text = "O's turn";

            }
            else
            {
                b.Content = "O";
                entry.Mark = 'O';
                uxTurn.Text = "X's turn";
            }
            b.IsEnabled = false;
            Entries.Add(entry);
            bool win;
            bool over;
            if (Turn >= 5)
            {
                win = IsWon();
                over = IsOver();

                if (win)
                {
                    uxTurn.Text = String.Format("{0} Wins!", entry.Mark);

                    DisableAllButtons();
                }
                else if(over)
                {
                    uxTurn.Text = "Cat's Game";
                    DisableAllButtons();
                }
            }

            Turn += 1;
        }

        public void DisableAllButtons()
        {
            var element = uxGrid.Children;
            List<FrameworkElement> elements = element.Cast<FrameworkElement>().ToList();
            List<Button> buttons = elements.OfType<Button>().ToList();
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }

        public bool IsWon()
        {
            return (CheckDiag() || CheckColumns() || CheckRows() );
        }

        public bool IsOver()
        {
            return (Turn >= 9);
        }

        public bool CheckDiag()
        {
            char? start = GetMark(0, 0);
            char? next = GetMark(1, 1);
            if( next == start && next != null)
            {
                next = GetMark(2, 2);
                if(next == start && next != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                start = GetMark(0, 2);
                next = GetMark(1, 1);
                if( next == start && next != null)
                {
                    next = GetMark(2, 0);
                    if(next == start && next != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckColumns()
        {
            return (CheckColumn(0) || CheckColumn(1) || CheckColumn(2));
        }

        public bool CheckColumn(int col)
        {
            List<Entry> temp = Entries.Where(i => i.Column == col).ToList();

            if(temp.Count < 3)
            {
                return false;
            }
            else
            {
                var mark = temp[0].Mark;
                foreach(Entry ent in temp)
                {
                    if(ent.Mark != mark)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool CheckRows()
        {
            return (CheckRow(0) || CheckRow(1) || CheckRow(2));
        }
        public bool CheckRow(int row)
        {
            List<Entry> temp = Entries.Where(i => i.Row == row).ToList();

            if (temp.Count < 3)
            {
                return false;
            }
            else
            {
                var mark = temp[0].Mark;
                foreach (Entry ent in temp)
                {
                    if (ent.Mark != mark)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public char? GetMark(int col, int row)
        {
            try
            {
                char c = Entries.Where(i => i.Column == col && i.Row == row).Select(k => k.Mark).First();
                return c;
            }
            catch(System.InvalidOperationException e)
            {
                return null;
            }
        }
    }
}
