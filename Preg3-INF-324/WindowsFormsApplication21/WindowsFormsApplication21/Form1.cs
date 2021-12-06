using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication21
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//RECUPERAR
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int x, y, mR=0, mG=0, mB=0;
            x = e.X; y = e.Y;
            for (int i = x; i < x + 10;i++)
                for (int j = y; j < y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }
            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            cR = mR;
            cG = mG;
            cB = mB;
            textBox1.Text = cR.ToString();
            textBox2.Text = cG.ToString();
            textBox3.Text = cB.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {//COPIAR
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cpoa.SetPixel(i, j, c);
                }
            pictureBox2.Image = cpoa;
        }

        private void button7_Click(object sender, EventArgs e)
        {//**RECUPERAR ROJO**
            //MUESTRA LO OBTENIDO DE LA BD
            SqlConnection con = new SqlConnection();
            SqlDataAdapter ada = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con.ConnectionString = "server=(local);user=usuario324;pwd=123456;database=Imagenes";
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "SELECT * FROM textura";
            ada.Fill(ds);
            DataRow row = ds.Tables[0].Rows[1];
            String t1 = ds.Tables[0].Rows[1]["text1"].ToString();
            String t2 = ds.Tables[0].Rows[1]["text2"].ToString();
            String t3 = ds.Tables[0].Rows[1]["text3"].ToString();

            int t11 = Int32.Parse(t1);
            int t22 = Int32.Parse(t2);
            int t33 = Int32.Parse(t3);

            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width-10; i+=10)
                for (int j = 0; j < bmp.Height-10; j+=10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i+10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR+c.R;
                            meG = meG+c.G;
                            meB = meB+c.B;
                        }
                    meR = meR /100;
                    meG = meG /100;
                    meB = meB /100;

                    meR = t11;
                    meG = t22;
                    meB = t33;
                    
                    if (((cR - 10) < meR) && (meR < (cR + 10)) && ((cG - 10) < meG) && (meG < (cG + 10)) && ((cB - 10) < meB) && (meB < (cB + 10)))
                        for (int k = i; k < i+10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Red);
                            }
                        
                    else
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);
                            }
                }
            pictureBox2.Image = cpoa;
        }

        private void button2_Click(object sender, EventArgs e)
        {//**RECUPERAR AMARILLO**
            //MUESTRA LO OBTENIDO DE LA BD
            SqlConnection con = new SqlConnection();
            SqlDataAdapter ada = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con.ConnectionString = "server=(local);user=usuario324;pwd=123456;database=Imagenes";
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "SELECT * FROM textura";
            ada.Fill(ds);
            DataRow row = ds.Tables[0].Rows[2];
            String t1 = ds.Tables[0].Rows[2]["text1"].ToString();
            String t2 = ds.Tables[0].Rows[2]["text2"].ToString();
            String t3 = ds.Tables[0].Rows[2]["text3"].ToString();

            int t11 = Int32.Parse(t1);
            int t22 = Int32.Parse(t2);
            int t33 = Int32.Parse(t3);

            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;

                    meR = t11;
                    meG = t22;
                    meB = t33;

                    if (((cR - 10) < meR) && (meR < (cR + 10)) && ((cG - 10) < meG) && (meG < (cG + 10)) && ((cB - 10) < meB) && (meB < (cB + 10)))
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Yellow);
                            }

                    else
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);
                            }
                }
            pictureBox2.Image = cpoa;
        }

        private void button8_Click(object sender, EventArgs e)
        {//**RECUPERAR VERDE**
            //MUESTRA LO OBTENIDO DE LA BD
            SqlConnection con = new SqlConnection();
            SqlDataAdapter ada = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con.ConnectionString = "server=(local);user=usuario324;pwd=123456;database=Imagenes";
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "SELECT * FROM textura";
            ada.Fill(ds);
            DataRow row = ds.Tables[0].Rows[3];
            String t1 = ds.Tables[0].Rows[3]["text1"].ToString();
            String t2 = ds.Tables[0].Rows[3]["text2"].ToString();
            String t3 = ds.Tables[0].Rows[3]["text3"].ToString();

            int t11 = Int32.Parse(t1);
            int t22 = Int32.Parse(t2);
            int t33 = Int32.Parse(t3);

            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap cpoa = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width - 10; i += 10)
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;

                    meR = t11;
                    meG = t22;
                    meB = t33;

                    if (((cR - 10) < meR) && (meR < (cR + 10)) && ((cG - 10) < meG) && (meG < (cG + 10)) && ((cB - 10) < meB) && (meB < (cB + 10)))
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                cpoa.SetPixel(k, l, Color.Green);
                            }

                    else
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                cpoa.SetPixel(k, l, c);
                            }
                }
            pictureBox2.Image = cpoa;
        }

        private void button9_Click(object sender, EventArgs e)
        {//GUARDAR
            SqlConnection con = new SqlConnection();
            SqlDataAdapter ada = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "server=(local);user=usuario324;password=123456;database=Imagenes";
            cmd.CommandText = "insert into textura(id_img,text1,text2,text3) values('','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
