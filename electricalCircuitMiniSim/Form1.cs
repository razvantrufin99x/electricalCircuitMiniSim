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
            public int value;

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
        private void Form1_Load(object sender, EventArgs e)
        {
            device d1 = new device();
            d1.padsInput.Add(new pad());
            d1.padsInput.Add(new pad());
            d1.padsOutput.Add(new pad());
            pad d1i1= new pad();
            d1.padsInput.Add(d1i1);
            pad d1i2 = new pad();
            d1.padsInput.Add(d1i2);
            pad d1o1 = new pad();
            d1.padsOutput.Add(d1o1);

            device d2 = new device();
            d2.padsInput.Add(new pad());
            d2.padsInput.Add(new pad());
            d2.padsOutput.Add(new pad());
            pad d2i1 = new pad();
            d2.padsInput.Add(d2i1);
            pad d2i2 = new pad();
            d2.padsInput.Add(d2i2);
            pad d2o1 = new pad();
            d2.padsOutput.Add(d2o1);

            circuit c = new circuit();  
            c.devices.Add(d1);
            c.devices.Add(d2);

            circuitlink cl = new circuitlink();
            cl.pairsoflinks.Add(new pairDevicePad());
            cl.pairsoflinks[0].thepad = d1.padsOutput[0];
            cl.pairsoflinks[0].thedevice = d1;
            cl.pairsoflinks.Add(new pairDevicePad());
            cl.pairsoflinks[1].thepad = d2.padsInput[0];
            cl.pairsoflinks[1].thedevice = d2;



            c.circuitlinkslist.Add(cl);

            /*
             la fiecare trecere din 1 in 0 sau 0 in 1 per circuit prin intermediul circuitlink list se vor transfera pe linie datele
            de continuat adica la fiecare trecere pad.value din 1 in 0 sau 0 in 1 se cauta pe circuit in circuitlinkslist si se transfera pentru fiecare 
            pereche gasita in circuitlink valoarea de la iesirea primului device la intrarea celuilalt cu update de la fiecare la fiecare a valorilor 
            de facut o interfata grafica simpla 
             */


        }
    }
}
