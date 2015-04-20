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

namespace StudentBankAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double savingsAccount = 0;
        double checkingAccount = 0;
        double amount;

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool isNumeric(string str)
        {
            if (str == null)
            {
                return true;
            }
            else
            {
                try
                {
                    double num = double.Parse(str);
                }
                catch (Exception nfe)
                {
                    return false;
                }

                return true;
            }

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Goodbye.");
            Application.Current.Shutdown();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (isNumeric(txtAmount.Text) == true)
            {
                amount = double.Parse(txtAmount.Text);

                if (rbtnSaving.IsChecked == true)
                {
                    if (rbtnDeposit.IsChecked == true)
                    {
                        MessageBoxResult result = MessageBox.Show("You are about to deposit " + amount.ToString("C") + " to your savings account. Press OK to continue.", "Warning", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.OK)
                        {
                            savingsAccount += amount;
                            txtBalance.Text = savingsAccount.ToString("C");
                        }
                    }
                    else if (rbtnWithdraw.IsChecked == true)
                    {
                        
                        MessageBoxResult result = MessageBox.Show("You are about to withdraw " + amount.ToString("C") + " from your savings account. Press OK to continue.", "Warning", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.OK)
                        {
                            if (double.Parse(txtAmount.Text) <= savingsAccount)
                            {
                                savingsAccount -= amount;
                                txtBalance.Text = savingsAccount.ToString("C");
                            }
                            else
                            {
                                MessageBox.Show("Insufficient balance!");
                            }
                        }
              
                    }
                    else
                    { 
                        MessageBox.Show("Please choose whether to deposit or withdraw.");
                    }
                }
                else if (rbtnChecking.IsChecked == true)
                {
                    if (rbtnDeposit.IsChecked == true)
                    {
                        MessageBoxResult result = MessageBox.Show("You are about to deposit " + amount.ToString("C") + " to your checking account. Press OK to continue.", "Warning", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.OK)
                        {
                            checkingAccount += amount;
                            txtBalance.Text = checkingAccount.ToString("C");
                        }
                        
                    }
                    else if (rbtnWithdraw.IsChecked == true)
                    {
                        
                        MessageBoxResult result = MessageBox.Show("You are about to withdraw " + amount.ToString("C") + " from your checking account. Press OK to continue.", "Warning", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.OK)
                        {
                            if (double.Parse(txtAmount.Text) <= checkingAccount)
                            {
                                checkingAccount -= amount;
                                txtBalance.Text = checkingAccount.ToString("C");
                            }
                            else
                            {
                                MessageBox.Show("Insufficient balance!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please choose whether to deposit or withdraw.");
                    }

                }
                else
                {
                    MessageBox.Show("Please choose savings or checking account.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a numeric amount.");
            }
            
        }
    }
}
