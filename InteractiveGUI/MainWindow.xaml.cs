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

namespace InteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Btn_Person_Click(object sender, RoutedEventArgs e)
        {

            Controller con = Controller.GetInstance();

            con.AddPerson();
            TB_FirstName.IsEnabled = true;
            TB_LastName.IsEnabled = true;
            TB_Age.IsEnabled = true;
            TB_TelephoneNo.IsEnabled = true;

            Btn_DeletePerson.IsEnabled = true;

            if(con.PersonCount > 1)
            {
            Btn_Up.IsEnabled = true;
            Btn_Down.IsEnabled = true;
            }

            ShowCurrentPerson();

        }

        private void Btn_DeletePerson_Click(object sender, RoutedEventArgs e)
        {

            Controller con = Controller.GetInstance();

            con.DeletePerson();

            if (con.PersonCount < 1)
            {
                Btn_DeletePerson.IsEnabled = false;
            }

            if (con.PersonCount < 2)
            {
                Btn_Up.IsEnabled = false;
                Btn_Down.IsEnabled = false;
            }

            ShowCurrentPerson();
        }

        private void Btn_Up_Click(object sender, RoutedEventArgs e)
        {

            Controller con = Controller.GetInstance();

            con.NextPerson();

            ShowCurrentPerson();

        }

        private void Btn_Down_Click(object sender, RoutedEventArgs e)
        {

            Controller con = Controller.GetInstance();

            con.PrevPerson();

            ShowCurrentPerson();

        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller con = Controller.GetInstance();

            if(con.PersonCount > 0)
            {
            con.CurrentPerson.FirstName = TB_FirstName.Text;
            }
        }


        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller con = Controller.GetInstance();
            if (con.PersonCount > 0)
            {
            con.CurrentPerson.LastName = TB_LastName.Text;
                
            }
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller con = Controller.GetInstance();
            if (con.PersonCount > 0)
            {
            con.CurrentPerson.Age = Convert.ToInt32(TB_Age.Text);

            }
        }

        private void TelephoneNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            Controller con = Controller.GetInstance();
            if (con.PersonCount > 0)
            {
            con.CurrentPerson.TelephoneNo = TB_TelephoneNo.Text;

            }
        }

        private void ShowCurrentPerson()
        {
            Controller con = Controller.GetInstance();
            if(con.PersonCount > 1)
            {
            TB_FirstName.Text = con.CurrentPerson.FirstName;
            TB_LastName.Text = con.CurrentPerson.FirstName;
            TB_Age.Text = con.CurrentPerson.Age.ToString();
            TB_TelephoneNo.Text = con.CurrentPerson.TelephoneNo;
            }
            else if(con.PersonCount < 1)
            {
                TB_FirstName.Text = null;
                TB_LastName.Text = null;
                TB_Age.Text = null;
                TB_TelephoneNo.Text = null;
            }

            Label_PersonCount.Content = "Person Count " + con.PersonCount;
            Label_Index.Content = "Index " + con.PersonIndex;
        }
    }
}
