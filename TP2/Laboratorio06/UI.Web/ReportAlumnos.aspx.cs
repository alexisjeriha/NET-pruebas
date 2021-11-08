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
            /*AlumnoInscripcionLogic logic = new AlumnoInscripcionLogic();
            List<Materia> materias = logic.GetAll();

            ReportDataSource rds = new ReportDataSource("DataSet1", materias);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReportMaterias.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();*/
        }
    }
}