using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dermatologic.Services;
using Page = System.Web.UI.Page;

namespace Dermatologica.Web
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

        public static void BindDropDownList(DropDownList list, List<T> source, bool band)
        {
            list.DataValueField = "Id";
            list.DataTextField = "CompleteName";
            list.DataSource = source;
            list.DataBind();
        }

        public static void BindDropDownListToEnum(DropDownList list, Type t)
        {
            if (t == typeof(T))
            {
                var source = EnumHelper.ToList<T>();
                list.DataValueField = "Key";
                list.DataTextField = "Value";
                list.DataSource = source;
                list.DataBind();
            }
        }

        public static void BindGrid(GridView grid, IList<T> source)
        {
            grid.DataSource = source;
            grid.DataBind();
        }

    }

    public class PageBase : Page
    {
        protected PageBase()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ES-pe");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ES-pe");
        }

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

        protected void ExportToExcel(string strFileName, DataGrid dg)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
            Response.ContentType = "application/excel";
            var sw = new System.IO.StringWriter();
            var htw = new HtmlTextWriter(sw);
            dg.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        protected CultureInfo CurrentCulture
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                return currentCulture;    
            }
        }
    }

    public static class DermaConstants
    {
        public const string PERSON_TYPE = "9B64DDB9-1C00-4A8B-99E5-FDCD96B3FF68";
        public const string PERSON_TYPE_MEDICAL = "DA913E86-1EB8-41E1-8DA0-81ABD6195254";
        public const string PERSON_TYPE_COSMEATRA = "FB546D8B-898C-4E19-8937-ADA8FC10F744";
        public const string PERSON_URSULA = "754124E0-7551-4E32-8DC4-5C4B80BAD8E2";
    }

    [DataContract]
    public enum Frecuence : int
    {
        [DataMember]
        [EnumDescription("Minutos")]
        Minutos = 0,

        [DataMember]
        [EnumDescription("Horas")]
        Horas = 1,

        [DataMember]
        [EnumDescription("Dias")]
        Dias = 2,

        [DataMember]
        [EnumDescription("Semanas")]
        Semanas = 3,
    }

    [DataContract]
    public enum DocumentType : int
    {
        [DataMember]
        [EnumDescription("DNI")]
        DNI = 0,

        [DataMember]
        [EnumDescription("Pasaporte")]
        Pasaporte = 1,

        [DataMember]
        [EnumDescription("Carnet de Extranjeria")]
        Carnet = 2
        
    }

    [DataContract]
    public enum InvoiceType : int
    {
        [DataMember]
        [EnumDescription("Recibo")]
        Recibo = 0,

        [DataMember]
        [EnumDescription("Boleta")]
        Boleta = 1,

        [DataMember]
        [EnumDescription("Factura")]
        Factura = 2

    }

    [DataContract]
    public enum PaymentType : int
    {
        [DataMember]
        [EnumDescription("Efectivo")]
        Efectivo = 0,

        [DataMember]
        [EnumDescription("Cheque en Banco")]
        Cheque = 1,

        [DataMember]
        [EnumDescription("Deposito en Cuenta")]
        Deposito = 2,

        [DataMember]
        [EnumDescription("Tarjeta de Credito/Debito")]
        Tarjeta = 2
    }

    [DataContract]
    public enum CurrencyType : int
    {
        [DataMember]
        [EnumDescription("Soles")]
        PEN = 0,

        [DataMember]
        [EnumDescription("Dolares")]
        USD = 1,

        [DataMember]
        [EnumDescription("Euros")]
        EUR = 2
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        private readonly string description;

        /// <summary>
        /// Gets the description stored in this attribute.
        /// </summary>
        /// <value>The description stored in the attribute.</value>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="EnumDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">The description to store in this attribute.
        /// </param>
        public EnumDescriptionAttribute(string description)
            : base()
        {
            this.description = description;
        }
    }

    public static class EnumHelper
    {
        /// <summary>
        /// Gets the <see cref="DescriptionAttribute" /> of an <see cref="Enum" />
        /// type value.
        /// </summary>
        /// <param name="value">The <see cref="Enum" /> type value.</param>
        /// <returns>A string containing the text of the
        /// <see cref="DescriptionAttribute"/>.</returns>
        public static string GetDescription(Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            var attributes = (EnumDescriptionAttribute[])
             fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        /// <summary>
        /// Converts the <see cref="Enum" /> type to an <see cref="IList{T}" /> 
        /// compatible object.
        /// </summary>
        /// <param name="type">The <see cref="Enum"/> type.</param>
        /// <returns>An <see cref="IList{T}"/> containing the enumerated
        /// type value and description.</returns>
        public static IList ToList<T>()
        {

            var list = new ArrayList();
            Array enumValues = Enum.GetValues(typeof(T));
            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<int, string>(Convert.ToInt32(Enum.Parse(typeof(T), value.ToString())), GetDescription(value)));
            }
            return list;
        }
    }
}