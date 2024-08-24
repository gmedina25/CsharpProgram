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

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Course choice;
        private int totalCreditHours = 0; // Variable to track registered credit hours


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");


            this.comboBox.Items.Add(course1);
            this.comboBox.Items.Add(course2);
            this.comboBox.Items.Add(course3);
            this.comboBox.Items.Add(course4);
            this.comboBox.Items.Add(course5);
            this.comboBox.Items.Add(course6);
            this.comboBox.Items.Add(course7);


            this.textBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            choice = (Course)(this.comboBox.SelectedItem);
            
            if(this.listBox.Items.Contains(choice) && choice.IsRegisteredAlready())
            {
                this.label3.Content = "You have already registered for the " + choice.ToString() + " course"; //Added string to label3 informing user they registered for that course already
            }
            else if (totalCreditHours < 9) //totalCreditHours cannot exceed 9 credit hours
            {
                this.listBox.Items.Add(choice); //Adds the selected course to the listbox of courses
                choice.SetToRegistered();
                totalCreditHours += 3; //Every course has 3 credit hours each and gets updated after a course is selected
                this.textBox.Text = Convert.ToString(totalCreditHours); //Text box updates the credit hours being displayed after courses are selected
                this.label3.Content = "Registration confirmed for course " + choice.ToString(); //Informs the user that their registration has been successfully confirmed
            }
            else
            {
                this.label3.Content = "You cannot register for more than 9 credit hours"; //Informs the user that they can't register for anymore course as they have reached the total credit limit
            }

            
            

            // TO DO - Create code to validate user selection (the choice object)
            // and to display an error or a registation confirmation message accordinlgy
            // Also update the total credit hours textbox if registration is confirmed for a selected course

        }
    }
}
