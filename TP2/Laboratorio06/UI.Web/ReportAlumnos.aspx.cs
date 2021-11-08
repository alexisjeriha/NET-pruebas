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


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionLogic logic = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alumnos = logic.GetAll();

            ReportDataSource rds = new ReportDataSource("DataSet1", alumnos);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReportAlumnos.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            AlumnoInscripcionLogic logic1 = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alumnos1 = logic1.GetRegulares();

            ReportDataSource rds1 = new ReportDataSource("DataSet2", alumnos1);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReportAlumnos.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds1);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}