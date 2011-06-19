using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
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
    
    [DataContract]
    public enum Frecuence
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
        private static string GetDescription(Enum value)
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
            int i = 0;
            foreach (Enum value in enumValues)
            {
                i = i + 1;
                list.Add(new KeyValuePair<int, string>(i, GetDescription(value)));
            }
            return list;
        }
    }
}