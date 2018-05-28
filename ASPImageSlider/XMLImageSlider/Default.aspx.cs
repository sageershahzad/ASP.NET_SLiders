using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPImageSlider
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetImageUrl();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            SetImageUrl();
        }

        private void SetImageUrl()
        {
            Random _rand = new Random();

            int i = _rand.Next(1, 5);

            Image1.ImageUrl = "~/Images/" + i.ToString() + ".jpg";

            Label1.Text = "Image Number " + i.ToString();
        }
    }
}