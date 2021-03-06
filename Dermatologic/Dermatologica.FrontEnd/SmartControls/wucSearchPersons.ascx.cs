﻿using System;
using System.Web.UI;

namespace Dermatologica.Web
{
    public partial class SmartControls_wucSearchPersons : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string SelectedValue
        {
            get
            {
                return ComboBox.SelectedValue;
            }
            set
            {
                ComboBox.SelectedValue = value;
            }
        }

        public string Text
        {
            get
            {
                return ComboBox.Text;
            }
            set
            {
                ComboBox.Text = value;
            }
        }

        public string EmptyMessage
        {
            set { ComboBox.EmptyMessage = value; }
        }

        public string PersonTypeControlName { get; set; }

        public bool EnableLoadOnDemand { set { ComboBox.EnableLoadOnDemand = value; } }

        public string WebServiceMethod
        {
            set
            {
                ComboBox.WebServiceSettings.Method = value;
            }
        }
    }
}