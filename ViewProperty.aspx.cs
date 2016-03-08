using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProperty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoggedUser loggedUser;
        Property property;
        {
            loggedUser = (LoggedUser)Session["User"];
            property = (Property)Session["Property"];
            if (loggedUser == null)
            {
                loggedUser = new LoggedUser();
            }
            if (property == null)
            {
                property = new Property();
            }
        }
        if (!IsPostBack)
        {
            if (Session["Host"] != null || Session["User"] != null)
            {
                FileUpload.Visible = true;
                btnUpload.Visible = true;
                AddPicLabel.Visible = true;
                SearchResultBtn.Visible = false;
                DoBookingBtn.Visible = false;
                ContactHostBtn.Visible = false;
            }

            // NEED PROPERTY ID TO WORK (refers to no id)
            // FetchImage(propertyId);
        }
    }
    protected void Request_Booking(object sender, EventArgs e)
    {
            Response.Redirect("RequestBooking.aspx");

    }
    protected void Search_Result(object sender, EventArgs e)
    {
        Response.Redirect("SearchResult.aspx");

    }
    protected void Contact_Host(object sender, EventArgs e)
    {
        Response.Redirect("SearchResult.aspx");

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        // Read the file and convert it to Byte Array
        string filePath = FileUpload.PostedFile.FileName;
        string filename = Path.GetFileName(filePath);
        string ext = Path.GetExtension(filename);
        string contenttype = String.Empty;

        //Set the contenttype based on File Extension
        switch (ext)
        {
            case ".jpg":
                contenttype = "image/jpg";
                break;
            case ".png":
                contenttype = "image/png";
                break;
            case ".gif":
                contenttype = "image/gif";
                break;
        }
        if (contenttype != String.Empty)
        {

            Stream fs = FileUpload.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            Host host = Session["Host"] != null ? (Host)Session["Host"] : null;
            User user = Session["User"] != null ? (User)Session["User"] : null;
            Image image = null;

            if (user != null)
            {
                // NEED PROPERTY ID TO WORK (-1 refers to no id)
                image = new Image(filename, contenttype, bytes, user.loginName, -1);
            }
            else
            {
                // NEED PROPERTY ID TO WORK (-1 refers to no id)
                image = new Image(filename, contenttype, bytes, host.loginName, -1);
            }

            if (image.saveImageInDb())
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "File Uploaded Successfully";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File format not recognised." +
                  " Upload Image formats (jpg/png/gif)";
            }
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "File format not recognised." +
              " Upload Image formats (jpg/png/gif)";
        }
    }

    protected void FetchImage(int propertyId)
    {
        int id = propertyId;
        Image.Visible = id != 0;
        if (id != 0)
        {
            Image image = new Image();
            List<Image> images = image.loadImagesFromDbWithPropertyId(id);
            Image.ImageUrl = "data:image/png;base64," + images[0].bytesInBase64;
        }
    }
}