using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The function will display an error message and reset the textbox if the tip value is less than 0.
        private void textTip_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt16(textTip.Text) < 0)
            {
                MessageBox.Show("Invalid Input");
                textTip.ResetText();
            }
        }

        // The function will display an error message and reset the textbox if the number of people is less than 1.
        private void textPeople_Validated(object sender, EventArgs e)
        {
            if (Convert.ToInt16(textPeople.Text) < 1)
            {
                MessageBox.Show("Input should be greater than 0");
                textPeople.ResetText();
            }
        }

        // The function will calculate and display the tip per person and the total amount per person.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double bill = double.Parse(textBill.Text);
                int tip = int.Parse(textTip.Text);
                int people = int.Parse(textPeople.Text);

                // Calculate tip per person
                double tip_per_person = ((tip * 0.01) * bill) / people;

                // Calculate total amount per person
                double total_per_person = (bill / people) + tip_per_person;

                DisplayTip.Text = tip_per_person.ToString("C");
                DisplayTotal.Text = total_per_person.ToString("C");
            }
            catch(Exception ex)
            {
                // Display error message
                MessageBox.Show("Invalid Input");
            }
        }

        // Reset function
        private void btnReset_Click(object sender, EventArgs e)
        {
            textBill.Clear();
            textTip.Clear();
            textPeople.Clear();
        }

        // Button to decrease the tip percentage by one.
        private void tipMinus_Click(object sender, EventArgs e)
        {
            int tip = int.Parse(textTip.Text);
            textTip.Text = Convert.ToString(--tip);
        }

        // Button to increase the tip percentage by one.
        private void tipPlus_Click(object sender, EventArgs e)
        {
            int tip = int.Parse(textTip.Text);
            textTip.Text = Convert.ToString(++tip);
        }

        // Button to decrease the number of people by 1.
        private void peopleMinus_Click(object sender, EventArgs e)
        {
            int people = int.Parse(textPeople.Text);
            textPeople.Text = Convert.ToString(--people);
        }

        // Button to increase the number of people by 1.
        private void peoplePlus_Click(object sender, EventArgs e)
        {
            int people = int.Parse(textPeople.Text);
            textPeople.Text = Convert.ToString(++people);
        }
    }
}
