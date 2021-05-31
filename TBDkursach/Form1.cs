using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace TBDkursach
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private SqlCommand command = null;
        private void view(string str)
        {
            dataAdapter = new SqlDataAdapter(str, sqlConnection);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            dataAdapter.Dispose();
            dataSet.Dispose();
        }

        private void procedure(string str)
        {
            command = new SqlCommand(str, sqlConnection);
            if (command.ExecuteNonQuery().ToString() == "-1")
            {
                MessageBox.Show("Ошибка!");
            }
            else
            {
                MessageBox.Show("Успешно!");
            }
            command.Dispose();
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["avtsln"].ConnectionString);
            sqlConnection.Open();

        }



        private void btavto_Click(object sender, EventArgs e)
        {
            view("select * from vAvto");

        }

        private void btsotrudniki_Click(object sender, EventArgs e)
        {
            view("select * from vSotrudniki");
        }

        private void bttsveta_Click(object sender, EventArgs e)
        {
            view("select * from vTsveta");
        }

        private void btprodaji_Click(object sender, EventArgs e)
        {
            view("select * from vProdaji");
        }

        private void btpostupleniya_Click(object sender, EventArgs e)
        {
            view("select * from vPostupleniya");
        }

        private void btklienti_Click(object sender, EventArgs e)
        {
            view("select * from vKlienti");
        }

        private void btproizvoditeli_Click(object sender, EventArgs e)
        {
            view("select * from vProizvoditeli");
        }

        private void btpostavshiki_Click(object sender, EventArgs e)
        {
            view("select * from vPostavshiki");
        }

        private void btkuzov_Click(object sender, EventArgs e)
        {
            view("select * from vTipiluzova");
        }

        private void btdoljnosti_Click(object sender, EventArgs e)
        {
            view("select * from vDoljnosti");
        }

        private void btstatusi_Click(object sender, EventArgs e)
        {
            view("select * from vStatusi");
        }

        private void bzklient_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pKlienti @FIO = N'{tbFIOk.Text}', @pasport = N'{tbpask.Text}', @adres = N'{tbadresk.Text}' ;");
        }

        private void bzpostavshik_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pPostavshiki @nazvanie = N'{tbnamep.Text}', @adres = N'{tvadresp.Text}', @telefon = N'{tbphonep.Text}' ;");
        }

        private void bzsotrudnik_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pSotrudniki @FIO = N'{tbFIOk.Text}',@doljnost = N'{tbIDds.Text}', @pasport = N'{tbpass.Text}', @adres = N'{tbadress.Text}',@telefon = N'{tbphones.Text}' ;");
        }

        private void bzavto_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pAvtomobili @manufacturer = N'{tbIDpa.Text}',@model = N'{tbmodel.Text}', @status = N'{tbIDsa.Text}', @price = N'{tbtsenaa.Text}',@creationdate = N'{tbyear.Text}',@color = N'{tbIDtsa.Text}', @bodytype = N'{tbIDta.Text}' ;");
        }

        private void bzproizvoditel_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pProizvoditeli @proizvoditel = N'{tbproizvoditel.Text}',@strana = N'{tbcountry.Text}' ;");
        }

        private void bzpostuplenie_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pPostupleniya @data = N'{tbdatap.Text}',@postavshik = N'{tbIDpp.Text}', @sotrudnik = N'{tbIDsp.Text}', @tsena = N'{tbtsenap.Text}',@avtomobil = N'{tbIDap.Text}' ;");
        }

        private void bzprodaja_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pProdaji @avtomobil = N'{tbIDapr.Text}',@sotrudnik = N'{tbIDspr.Text}', @klient = N'{tbIDkpr.Text}', @tsena = N'{tbIDtsenapr.Text}',@dataprodaji = N'{tbdatapr.Text}' ;");
        }
    }
}
