﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using InscripcionesCursos.BE;
using System.IO;
using System.Threading;

namespace InscripcionesCursos.Privado.Alumnos
{
    public partial class PlanDeEstudios : System.Web.UI.Page
    {
        #region Constants & Variables

        const int UserTypeStudent = 2;
        const string CarreraContador = "Contador Público";

        #endregion

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!Utils.CheckLoggedUser(Session["user"], UserTypeStudent))
                        Response.Redirect(Page.ResolveUrl("~") + ConfigurationManager.AppSettings["UrlLogin"]);

                    if (!Utils.CheckAccountStatus(Session["user"], UserTypeStudent))
                        Response.Redirect(Page.ResolveUrl("~") + ConfigurationManager.AppSettings["UrlStudentPasswordChange"]);

                    lblTitulo.Text = String.Format(ConfigurationManager.AppSettings["ContentMainTitlePlanEstudio"], ((Usuario)(Session["user"])).Carrera);

                    if (((Usuario)(Session["user"])).Carrera == CarreraContador)
                        contentContador.Visible = true;
                    else
                        contentAdministracion.Visible = true;
                }
            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                LogWriter log = new LogWriter();
                log.WriteLog(ex.Message, "Page_Load", Path.GetFileName(Request.PhysicalPath));
                throw ex;
            }
        }

        #endregion
    }
}