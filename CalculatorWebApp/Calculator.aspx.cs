using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorWebApp
{
    public partial class Calculator : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

                ViewState["CurrentValue"] = string.Empty;
                ViewState["PreviousValue"] = string.Empty;
                ViewState["Operation"] = string.Empty;
                ViewState["Expression"] = string.Empty;
                lblDisplay.Text = "0";
            }
        }

        protected void btnDigit_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (lblDisplay.Text == "0" || ViewState["Operation"].ToString() == "=")
            {
                ViewState["CurrentValue"] = button.Text;
                lblDisplay.Text = ViewState["CurrentValue"].ToString();
                ViewState["Expression"] = ViewState["CurrentValue"].ToString();
                ViewState["Operation"] = string.Empty;
            }
            else
            {
                ViewState["CurrentValue"] += button.Text;
                lblDisplay.Text = ViewState["CurrentValue"].ToString();
                ViewState["Expression"] += button.Text;
            }
        }

        protected void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!ViewState["CurrentValue"].ToString().Contains("."))
            {
                ViewState["CurrentValue"] += ".";
                lblDisplay.Text = ViewState["CurrentValue"].ToString();
                ViewState["Expression"] += ".";
            }
        }

        protected void btnOperation_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (ViewState["CurrentValue"].ToString() != string.Empty)
            {
                if (ViewState["Operation"].ToString() != string.Empty && ViewState["Operation"].ToString() != "=")
                {
                    btnEquals_Click(sender, e);
                }

                ViewState["PreviousValue"] = ViewState["CurrentValue"];
                ViewState["Operation"] = button.Text;
                ViewState["CurrentValue"] = string.Empty;

                
                lblDisplay.Text = ViewState["PreviousValue"].ToString() + " " + button.Text;
                ViewState["Expression"] = lblDisplay.Text;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ViewState["CurrentValue"] = string.Empty;
            ViewState["PreviousValue"] = string.Empty;
            ViewState["Operation"] = string.Empty;
            ViewState["Expression"] = string.Empty;
            lblDisplay.Text = "0";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var currentValue = ViewState["CurrentValue"].ToString();
            if (currentValue.Length > 0)
            {
                ViewState["CurrentValue"] = currentValue.Remove(currentValue.Length - 1);
                lblDisplay.Text = ViewState["CurrentValue"].ToString();
                if (ViewState["CurrentValue"].ToString() == "")
                {
                    lblDisplay.Text = "0";
                }
                ViewState["Expression"] = lblDisplay.Text;
            }
        }

        protected void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                double previousValue = string.IsNullOrEmpty(ViewState["PreviousValue"].ToString())
                                        ? 0
                                        : Convert.ToDouble(ViewState["PreviousValue"], CultureInfo.InvariantCulture);
                double currentValue = string.IsNullOrEmpty(ViewState["CurrentValue"].ToString())
                                        ? 0
                                        : Convert.ToDouble(ViewState["CurrentValue"], CultureInfo.InvariantCulture);
                double result = 0;

                switch (ViewState["Operation"].ToString())
                {
                    case "+":
                        result = previousValue + currentValue;
                        break;
                    case "-":
                        result = previousValue - currentValue;
                        break;
                    case "*":
                        result = previousValue * currentValue;
                        break;
                    case "/":
                        if (currentValue != 0)
                        {
                            result = previousValue / currentValue;
                        }
                        else
                        {
                            lblDisplay.Text = "Error";
                            ViewState["Expression"] = string.Empty;
                            return;
                        }
                        break;
                    default:
                        lblDisplay.Text = "Error";
                        ViewState["Expression"] = string.Empty;
                        return;
                }

                ViewState["CurrentValue"] = result.ToString(CultureInfo.InvariantCulture);
                ViewState["Operation"] = "=";
                lblDisplay.Text = result.ToString("G", CultureInfo.InvariantCulture);
                ViewState["Expression"] = string.Empty;
            }
            catch
            {
                lblDisplay.Text = "Error";
                ViewState["Expression"] = string.Empty;
            }
        }
    }
}