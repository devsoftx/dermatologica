using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dermatologic.Domain;
using Dermatologic.Services;

namespace ASP.App_Code
{
    public static class BindControl<T>
    {
        public static void BindDropDownList(DropDownList list, IList<T> source)
        {
            list.DataValueField = "Id";
            list.DataTextField = "Name";
            list.DataSource = source;
            list.DataBind();
        }

        public static void BindDropDownListToEnum(DropDownList list, IDictionary<int,string> source)
        {
            list.DataValueField = "Key";
            list.DataTextField = "Value";
            list.DataSource = source;
            list.DataBind();
        }

        public static void BindGrid(GridView grid, IList<T> source)
        {
            grid.DataSource = source;
            grid.DataBind();
        }

        public static void BindRepeater(Repeater rep, List<T> source)
        {
            rep.DataSource = source;
            rep.DataBind();
        }
    }

    public class PageBase : Page
    {
        private readonly AbstractServiceFactory bussinessFactory = new ServiceFactory();

        protected AbstractServiceFactory BussinessFactory
        {
            get { return bussinessFactory; }
        }

        protected Guid? CreatedBy
        {
            get
            {
                var userId = Session["UserId"];
                return userId != null ? new Guid(Session["UserId"].ToString()) : Guid.Empty;
            }
        }

        protected Guid? ModifiedBy
        {
            get
            {
                var userId = Session["UserId"];
                return userId != null ? new Guid(Session["UserId"].ToString()) : Guid.Empty;
            }
        }

        protected DateTime? LastModified
        {
            get
            {
                return DateTime.Now;
            }
        }

        protected DateTime? CreationDate
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
    
}