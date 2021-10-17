using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusterSiparis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=Techh; Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {//EKLE
            String t1 = textBox1.Text; //SiparişNo
            String t2 = textBox1.Text; //SiparişTürü
            String t3 = textBox1.Text; //TeslimTarihi
            String t4 = textBox1.Text; //Müşteri
            String t5 = textBox1.Text; //ToplamTutar
            String t6 = textBox1.Text; //ParaBirimi

            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Siparis (SiparisNo,SiparisTuru,TeslimTarihi,Musteri,ToplamTutar,ParaBirimi) VALUES('" + t1 + "','" + t2 + "','" + t3 + "','" + t4 + "','" + t5 + "','" + t6 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele(); 
        }
        private void listele()//veritabanındaki kayıtların görüntülenmesi
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Siparis", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void malzemeKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void siparişKalemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {//SİL
            String t1 = textBox1.Text; //seçilen satırın kodunu alır,
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Siparis WHERE SiparisNo=('" + t1 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {//GÜNCELLEME
            String t1 = textBox1.Text; //SiparişNo
            String t2 = textBox1.Text; //SiparişTürü
            String t3 = textBox1.Text; //TeslimTarihi
            String t4 = textBox1.Text; //Müşteri
            String t5 = textBox1.Text; //ToplamTutar
            String t6 = textBox1.Text; //ParaBirimi

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Siparis SET SiparisNo='"+t1+ "'SiparisTuru='" + t2 + "'TeslimTarihi='" + t3 + "'Musteri='" + t4 + "'ToplamTutar='" + t5 + "' ParaBirimi='" + t6 + "' WHERE SiparisNo='"+t1+"' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }
    }
}
