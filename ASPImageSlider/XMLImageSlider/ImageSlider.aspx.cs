using System;
using System.Data;
using System.Linq;

namespace ASPImageSlider
{
    public partial class ImageSlider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadImageData();
            }
        }
        private void LoadImageData()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/ImageData.xml"));
            ViewState["ImageData"] = ds;

            ViewState["ImageDisplayed"] = 1;
            DataRow imageDataRow = ds.Tables["image"].Select().FirstOrDefault(x => x["order"].ToString() == "1");
            Image1.ImageUrl = "~/Images/" + imageDataRow["name"].ToString();
            lblImageName.Text = imageDataRow["name"].ToString();
            lblImageOrder.Text = imageDataRow["order"].ToString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int i = (int)ViewState["ImageDisplayed"];
            i = i + 1;
            ViewState["ImageDisplayed"] = i;

            DataRow imageDataRow = ((DataSet)ViewState["ImageData"]).Tables["image"].Select().FirstOrDefault(x => x["order"].ToString() == i.ToString());
            if (imageDataRow != null)
            {
                Image1.ImageUrl = "~/Images/" + imageDataRow["name"].ToString();
                lblImageName.Text = imageDataRow["name"].ToString();
                lblImageOrder.Text = imageDataRow["order"].ToString();
            }
            else
            {
                LoadImageData();
            }
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Timer1.Enabled)
            {
                Timer1.Enabled = false;
                Button1.Text = "Start Slideshow";
            }
            else
            {
                Timer1.Enabled = true;
                Button1.Text = "Stop Slideshow";
            }
        }
    }
}