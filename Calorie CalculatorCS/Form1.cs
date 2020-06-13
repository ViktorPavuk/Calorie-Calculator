using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calorie_CalculatorCS
{
    public partial class CaloriesCalculator : Form
    {
        public double[] activityCoefList = { 1.0, 1.2, 1.375, 1.55, 1.725, 1.9 };

        public string[] activity =
            {
                "Basal Metabolic Rate (BMR)",
                "Sedentary (little or no excersize)",
                "Light Activity (exercise 1-3 days/week)",
                "Moderately activity (exercise/sports 4-5 days/week)",
                "Very activity (intense exercise/sports 6-7 days/week)",
                "Extreme activity (intense hard exercise/sports & physical job)",
            };

        public int age = 25, ageMetric = 25;
        public char gender = 'M';
        public int totalHeightInch = 72;
        public int heightFeet = 6, heightInch = 0;
        public double heightCm = 183;
        public double weightPound = 145;
        public double weightKg = 65;
        public double activityCoef = 1.0;
        public double BMR = 1.0;
        public double result = 0;

        public CaloriesCalculator()
        {
            InitializeComponent();

            activityBox.DataSource = activity;
            activityBoxMetric.DataSource = activity;
        }

        private void ageBox_TextChanged(object sender, EventArgs e)
        {
            if (ageBox.Text == String.Empty)
                age = 25;
            else
                int.TryParse(ageBox.Text, out age);
        }

        // Printing results for US units
        private void button1_Click(object sender, EventArgs e)
        {
            totalHeightInch = heightFeet * 12 + heightInch;
            heightCm = totalHeightInch * 2.54;
            weightKg = weightPound * 0.453592;

            if (genderFemale.Checked)
                BMR = 9.247 * weightKg + 3.098 * heightCm - 4.33 * age + 447.593;
            else
                BMR = 13.397 * weightKg + 4.799 * heightCm - 5.677 * age + 88.362;

            result = Math.Ceiling(BMR * activityCoef);
            labelResultMaintenance.Text = result.ToString();
            labelResultSlow.Text = (result - 250).ToString();
            labelResultModerate.Text = (result - 500).ToString();
            labelResultFast.Text = (result - 1000).ToString();
        }

        private void activityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < activity.Length; i++)
            {
                if (activityBox.Text == activity[i])
                    activityCoef = activityCoefList[i];
            }
        }

        private void heightBoxUSFeet_TextChanged(object sender, EventArgs e)
        {
            if (heightBoxUSFeet.Text == String.Empty)
                heightFeet = 6;
            else
                int.TryParse(heightBoxUSFeet.Text, out heightFeet);
        }

        private void heightBoxUSInch_TextChanged(object sender, EventArgs e)
        {
            if(heightBoxUSInch.Text == String.Empty)
                heightInch = 0;
            else
                int.TryParse(heightBoxUSInch.Text, out heightInch);
        }

        private void weightBoxUS_TextChanged(object sender, EventArgs e)
        {
            if (weightBoxUS.Text == String.Empty)
                weightPound = 145;
            else
                double.TryParse(weightBoxUS.Text, out weightPound);
        }

        private void ageBoxMetric_TextChanged(object sender, EventArgs e)
        {
            if (ageBoxMetric.Text == String.Empty)
                ageMetric = 25;
            else
                int.TryParse(ageBoxMetric.Text, out ageMetric);
        }

        private void activityBoxMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < activity.Length; i++)
            {
                if (activityBox.Text == activity[i])
                    activityCoef = activityCoefList[i];
            }
        }

        private void heightBoxMetric_TextChanged(object sender, EventArgs e)
        {
            if (heightBoxMetric.Text == String.Empty)
                heightCm = 183;
            else
                double.TryParse(heightBoxMetric.Text, out heightCm);
        }

        private void weightBoxMetric_TextChanged(object sender, EventArgs e)
        {
            if (weightBoxMetric.Text == String.Empty)
                weightKg = 65;
            else
                double.TryParse(weightBoxMetric.Text, out weightKg);
        }

        // Printing results for metric units
        private void button2_Click(object sender, EventArgs e)
        {
            if (genderFemaleMetric.Checked)
                BMR = 9.247 * weightKg + 3.098 * heightCm - 4.33 * ageMetric + 447.593;
            else
                BMR = 13.397 * weightKg + 4.799 * heightCm - 5.677 * ageMetric + 88.362;

            result = Math.Ceiling(BMR * activityCoef);
            labelResultMaintenanceMetric.Text = result.ToString();
            labelResultSlowMetric.Text = (result - 250).ToString();
            labelResultModerateMetric.Text = (result - 500).ToString();
            labelResultFastMetric.Text = (result - 1000).ToString();
        }

    }
}
