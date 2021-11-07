using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Personas : System.Web.UI.Page
    {
        PersonaLogic _logic;

        private PersonaLogic Logic
        {
            get
            {
                if (_logic ==null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }

        private void LoadDrop()
        {
            PersonaLogic pl = new PersonaLogic();

            iDPlanDropDownList.DataSource = pl.GetAll();
            iDPlanDropDownList.DataTextField = "ID Plan";
            iDPlanDropDownList.DataTextField = "IDPlan";
            iDPlanDropDownList.DataBind();

            ListItem init = new ListItem();
            init.Text = "--Seleccionar Especialidad--";
            init.Value = "-1";

            iDPlanDropDownList.Items.Add(init);
            iDPlanDropDownList.SelectedValue = "-1";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                LoadDrop();
            }
        }
    }
}