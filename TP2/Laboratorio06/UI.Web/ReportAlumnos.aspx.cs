using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ReportAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {

            AlumnoInscripcionLogic logic = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alumnos = logic.GetAll();
            ReportDataSource rds = new ReportDataSource("DataSet1", alumnos);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReportAlumnos.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;

        }

        protected void btnRegulares_Click(object sender, EventArgs e)
        {
            
            AlumnoInscripcionLogic logic1 = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alumnos1 = logic1.GetRegulares();  
            ReportDataSource rds1 = new ReportDataSource("DataSet1", alumnos1);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReportAlumnos.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds1);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }

        protected void btnAprobados_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionLogic logic2 = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alumnos2 = logic2.GetAprobados();
            ReportDataSource rds2 = new ReportDataSource("DataSet1", alumnos2);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReportAlumnos.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds2);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }

        protected void btnLibres_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionLogic logic3 = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alumnos3 = logic3.GetLibres();
            ReportDataSource rds3 = new ReportDataSource("DataSet1", alumnos3);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReportAlumnos.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds3);
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }
    }
}