using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace electricalCircuitMiniSim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public class pairDevicePad
        {
            public device thedevice;
            public pad thepad;
            public pairDevicePad() { }

        }
        public class pad
        {
            public pad() { }
            public int value = 0;

        }

        public class device
        {
           
            public List<pad> padsInput = new List<pad>();
            public List<pad> padsOutput = new List<pad>();
            public device() { }



        }
        public class circuitlink
        {
            public List<pairDevicePad> pairsoflinks = new List<pairDevicePad>();
        }
        public class circuit
        {
            public List<device> devices = new List<device>();
            public List<circuitlink> circuitlinkslist = new List<circuitlink>();

            public circuit() { }
        }

        //init all

        public device d1 = new device();
        public pad d1i1 = new pad();
        public pad d1i2 = new pad();

        public pad d1o1 = new pad();

        public device d2 = new device();
        public pad d2i1 = new pad();
        public pad d2i2 = new pad();
        public pad d2o1 = new pad();


        circuit c = new circuit();

        circuitlink cl = new circuitlink();


        private void Form1_Load(object sender, EventArgs e)
        {
            
            d1.padsInput.Add(new pad());
            d1.padsInput.Add(new pad());
            d1.padsOutput.Add(new pad());
          
            d1.padsInput.Add(d1i1);
            
            d1.padsInput.Add(d1i2);
            
            d1.padsOutput.Add(d1o1);

           
            d2.padsInput.Add(new pad());
            d2.padsInput.Add(new pad());
            d2.padsOutput.Add(new pad());
            
            d2.padsInput.Add(d2i1);
            
            d2.padsInput.Add(d2i2);
           
            d2.padsOutput.Add(d2o1);

             
            c.devices.Add(d1);
            c.devices.Add(d2);
            
            cl.pairsoflinks.Add(new pairDevicePad());
            cl.pairsoflinks[0].thepad = d1.padsOutput[0];
            cl.pairsoflinks[0].thedevice = d1;
            cl.pairsoflinks.Add(new pairDevicePad());
            cl.pairsoflinks[1].thepad = d2.padsInput[0];
            cl.pairsoflinks[1].thedevice = d2;



            c.circuitlinkslist.Add(cl);

            //set the values initials
            d1i2.value = 1;
            d1i1.value = 0;
            d1o1.value = 0;

            d2i1.value = 0;
            d2i2.value = 1;
            d2o1.value = 0;

            //d1
            this.textBox1.Text = "0";
            this.textBox2.Text = "1";
            this.textBox3.Text = "0";
            //d2
            this.textBox4.Text = "0";
            this.textBox5.Text = "1";
            this.textBox6.Text = "0";
            //d1
            this.textBox1.BackColor = Color.Red;
            this.textBox2.BackColor = Color.Green;
            this.textBox3.BackColor = Color.Red;
            //d2
            this.textBox4.BackColor = Color.Red;
            this.textBox5.BackColor = Color.Green;
            this.textBox6.BackColor = Color.Red;
            /*
             la fiecare trecere din 1 in 0 sau 0 in 1 per circuit prin intermediul circuitlink list se vor transfera pe linie datele
            de continuat adica la fiecare trecere pad.value din 1 in 0 sau 0 in 1 se cauta pe circuit in circuitlinkslist si se transfera pentru fiecare 
            pereche gasita in circuitlink valoarea de la iesirea primului device la intrarea celuilalt cu update de la fiecare la fiecare a valorilor 
            de facut o interfata grafica simpla 
             */


        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (d1i1.value == 0) { 
                d1i1.value = 1;
                this.textBox1.Text = "1";
                if (d1i1.value == 1) { this.textBox1.BackColor = Color.Green; }
                else { this.textBox1.BackColor = Color.Red; }
                if (d1i2.value == d1i1.value)
                { 
                    d1o1.value = 1;
                    this.textBox3.Text = "1";
                    if (d1o1.value == 1) { this.textBox3.BackColor = Color.Green; }
                    else { this.textBox3.BackColor = Color.Red; }
                    d2i1.value = 1;

                    this.textBox4.Text = "1";
                    if (d2i1.value == 1) { this.textBox4.BackColor = Color.Green; }
                    else { this.textBox4.BackColor = Color.Red; }
                }
                else 
                {
                    d1o1.value = 0;
                    this.textBox3.Text = "0";
                    if (d1o1.value == 1) { this.textBox3.BackColor = Color.Green; }
                    else { this.textBox3.BackColor = Color.Red; }
                    d2i1.value = 0;
                    this.textBox4.Text = "0";
                    if (d2i1.value == 1) { this.textBox4.BackColor = Color.Green; }
                    else { this.textBox4.BackColor = Color.Red; }
                }

                
                
                
                if (d2i2.value == d2i1.value)
                {
                    d2o1.value = 1;
                    this.textBox6.Text = "1";
                    if (d2o1.value == 1) { this.textBox6.BackColor = Color.Green; }
                    else { this.textBox6.BackColor = Color.Red; }
                    
                
                }
                else
                {
                    d2o1.value = 0;
                    this.textBox6.Text = "0";
                    if (d2o1.value == 1) { this.textBox6.BackColor = Color.Green; }
                    else { this.textBox6.BackColor = Color.Red; }
                   
                    
                }


            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (d1i2.value == 1)
            {
                d1i2.value = 0;
                this.textBox2.Text = "1";
                if (d1i2.value == 1) { this.textBox1.BackColor = Color.Green; }
                else { this.textBox1.BackColor = Color.Red; }
                if (d1i2.value == d1i1.value)
                {
                    d1o1.value = 1;
                    this.textBox3.Text = "1";
                    if (d1o1.value == 1) { this.textBox3.BackColor = Color.Green; }
                    else { this.textBox3.BackColor = Color.Red; }
                    d2i1.value = 1;

                    this.textBox4.Text = "1";
                    if (d2i1.value == 1) { this.textBox4.BackColor = Color.Green; }
                    else { this.textBox4.BackColor = Color.Red; }
                }
                else
                {
                    d1o1.value = 0;
                    this.textBox3.Text = "0";
                    if (d1o1.value == 1) { this.textBox3.BackColor = Color.Green; }
                    else { this.textBox3.BackColor = Color.Red; }
                    d2i1.value = 0;
                    this.textBox4.Text = "0";
                    if (d2i1.value == 1) { this.textBox4.BackColor = Color.Green; }
                    else { this.textBox4.BackColor = Color.Red; }
                }




                if (d2i2.value == d2i1.value)
                {
                    d2o1.value = 1;
                    this.textBox6.Text = "1";
                    if (d2o1.value == 1) { this.textBox6.BackColor = Color.Green; }
                    else { this.textBox6.BackColor = Color.Red; }


                }
                else
                {
                    d2o1.value = 0;
                    this.textBox6.Text = "0";
                    if (d2o1.value == 1) { this.textBox6.BackColor = Color.Green; }
                    else { this.textBox6.BackColor = Color.Red; }


                }


            }
        }
    }
}
