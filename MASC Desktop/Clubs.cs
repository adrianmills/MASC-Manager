using Business_Logic.DataRetrival.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MASC_Desktop
{
    public partial class Clubs : Form
    {
        IClubData _clubdata;
        public Clubs(IClubData clubData)
        {
            _clubdata = clubData;
            
            
            InitializeComponent();
        }

        private void Clubs_Load(object sender, EventArgs e)
        {
            clubsSource.DataSource = _clubdata.Clubs;
        }
    }
}
