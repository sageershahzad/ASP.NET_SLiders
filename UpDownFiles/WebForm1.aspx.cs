using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UpDownFiles
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetValue();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            GetValue();
        }

        private void GetValue()
        {
            if (BrowseUpload.HasFile)
            {
                BrowseUpload.PostedFile.SaveAs(Server.MapPath("~/Data/") + BrowseUpload.FileName);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("File", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("Type", typeof(string));

            foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Data")))
            {
                FileInfo fi = new FileInfo(strFile);

                dt.Rows.Add(fi.Name, fi.Length, GetFileTypeByExtenstion(fi.Extension));
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        private string GetFileTypeByExtenstion(string extension)
        {
            switch (extension.ToLower())
            {
                case ".doc":
                case ".docx":
                    return "Microsoft Word Document";

                case ".pdf":
                    return "Portable Document Format";

                case ".png":
                    return "Portable Network Graphics";

                case ".jpg":
                    return "Joint Picture Experts Group";

                case ".txt":
                    return "Text Format";

                 default:
                     return "Un-Known";

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "filename="
                                                             + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Data/")
                                      + e.CommandArgument);
                Response.End();
            }
        }
    }
}