using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyImpenetrableSite
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Encode user input
            string rawInput = txtSearchTerms.Text;
            string encodedInput = Server.HtmlEncode(rawInput);
            lblSearchTerms.Text = "You searched for: " + encodedInput;  
        }
    }
}