using System;
using System.Windows.Forms;

namespace _6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            button1.Visible = false;
        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            button1.Visible = true;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void monthpay_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }


        public void Button1_Click(object sender, EventArgs e)     //monthpay
        {
            if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0) || (textBox3.Text.Length == 0))
                MessageBox.Show("empty");
            else
            {
                int pokupka = int.Parse(textBox1.Text);
                int per_plat = int.Parse(textBox2.Text);
                decimal fact_proc = decimal.Parse(textBox3.Text) / 100;


                if (comboBox1.SelectedIndex == 0)
                {
                    var mp = ((pokupka - per_plat) * fact_proc) / 12;
                    var mp2 = (pokupka - per_plat) / 12;  
                    var xx = Convert.ToString(Math.Round(mp+mp2, 2));
                    monthpay.Text = xx;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    var mp = ((pokupka - per_plat) + pokupka * fact_proc) / 24;
                    var mp2 = (pokupka - per_plat) / 24;
                    var xx = Convert.ToString(Math.Round(mp + mp2, 2));
                    monthpay.Text = xx;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    var mp = ((pokupka - per_plat) + pokupka * fact_proc) / 36; 
                    var mp2 = (pokupka - per_plat) / 36;
                    var xx = Convert.ToString(Math.Round(mp + mp2, 36));
                    monthpay.Text = xx;
                }

            }
        }

        public void button2_Click(object sender, EventArgs e)//payschema
        {
            monthpay.Clear();
            static decimal div_r(decimal num_one, decimal num_two) //функция делит и округляет
            {
            decimal f_div_r = Math.Round(num_one / num_two, 2);
            return f_div_r;
            }

            decimal procik, pok, proc_, //процик - общий процент, пок - платеж по телу долга за период
                    income = 0, inc = 0,
                    per_plat = Convert.ToDecimal(textBox2.Text),//firstpay
                    pokupka_ = Convert.ToDecimal(textBox1.Text),//count
                    fact_proc = Convert.ToDecimal(textBox3.Text) / 100, // x/100
                    pokupka = pokupka_ - per_plat,//долг банку
                    proc = fact_proc * pokupka;
            decimal pok_ = 0, procik_ = 0;

            if (radioButton1.Checked) //ежемесячный платеж
            {
                if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0) || (textBox3.Text.Length == 0))
                    MessageBox.Show("empty");//empty textboxes

                else
                {
                    dataGridView1.Rows.Clear();
                    if (comboBox1.SelectedIndex == 0)
                    {
                        procik = div_r(proc, 12);//весь процент делим на период
                        pok = div_r(pokupka, 12);
                        for (var i = 1; i <= 12; i++)// i - period
                        {
                            income += pok + procik;
                            dataGridView1.Rows.Add(i, pok, procik, income);                                                                                               
                        }
                    }

                    else if (comboBox1.SelectedIndex == 1)
                    {
                        procik = div_r(proc, 24);//весь процент делим на период
                        pok = div_r(pokupka, 24);
                        for (var i = 1; i <= 24; i++)// i - period
                        {
                            income += pok + procik;
                            dataGridView1.Rows.Add(i, pok, procik, income);
                        }
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        procik = div_r(proc, 36);//весь процент делим на период
                        pok = div_r(pokupka, 36);
                        for (var i = 1; i <= 36; i++)// i - period
                        {
                            income += pok + procik;
                            dataGridView1.Rows.Add(i, pok, procik, income);
                        }
                    }
                }
            }






            if (radioButton2.Checked)//ежеквартально
            {
                if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0) || (textBox3.Text.Length == 0))
                    MessageBox.Show("empty"); //chek texboxes
                else
                {
                    dataGridView1.Rows.Clear();
                    

                    if (comboBox1.SelectedIndex == 0) //chosen period
                    {
                        pok = div_r(pokupka, 12);//весь долг делим на период 

                        for (var i = 1; i <= 12; i++)// i - period
                        {
                            procik = div_r(proc, 12);
                            procik_ += procik;
                            inc = (pok + procik);
                            income += inc; // сложение с присваиванием
                            pok_ += pok;
                           

                            if (i % 3 == 0)
                            dataGridView1.Rows.Add((i), pok_, procik_, income);   
                        }
                    }

                    else if (comboBox1.SelectedIndex == 1)///
                    {
                        fact_proc += fact_proc * 2;
                        pok = div_r(pokupka, 24);//весь долг делим на период 

                        for (var i = 1; i <= 24; i++)// i - period
                        {
                            procik = div_r(proc*2, 12);
                            procik_ += procik;
                            inc = (pok + procik);
                            income += inc; // сложение с присваиванием
                            pok_ += pok;

                            if (i % 3 == 0)
                                dataGridView1.Rows.Add((i), pok_, procik_, income);
                        }
                    }

                    else if (comboBox1.SelectedIndex == 2)
                    {
                        procik = div_r(proc*3, 12);
                        procik_ += procik;
                        pok = div_r(pokupka, 36);//весь долг делим на период 
                                             
                        for (var i = 1; i <= 36; i++)// i - period
                        {
                            inc = (pok + procik);
                            income += inc; // сложение с присваиванием
                            pok_ += pok;

                            if (i % 3 == 0)
                                dataGridView1.Rows.Add((i), pok_, procik_, income);
                        }
                    }
                }
            }
        }
    }
}
