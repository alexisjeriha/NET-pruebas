using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ReportePlanes : Form
    {
        public ReportePlanes()
        {
            InitializeComponent();
        }
        private void ReportePlanes_Load(object sender, EventArgs e)
        {
            PlanLogic logic = new PlanLogic();
            List<Plan> planes = logic.GetAll();

            ReportDataSource rds = new ReportDataSource("ReportePaises", planes);
            rvPlanes.LocalReport.ReportPath = @"D:\Users\ajeri\Source\Repos\NET-pruebas\TP2\Laboratorio06\UI.Desktop\ReportPlanes.rdlc";
            rvPlanes.LocalReport.DataSources.Clear();
            rvPlanes.LocalReport.DataSources.Add(rds);
            rvPlanes.RefreshReport();
        }

    }
}
