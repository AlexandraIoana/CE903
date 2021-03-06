﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProperty : System.Web.UI.Page
{

    Property property;

    protected void Page_Load(object sender, EventArgs e)
    {
        int propertyId = -1;
        try
        {
            propertyId = int.Parse(Request.QueryString["propertyId"]);
        }
        catch (Exception)
        {
            Response.Redirect("SearchResult.aspx");
        }
        Session["propertyId"] = propertyId;
      
        if (!IsPostBack)
        {
            Host host = (Host)Session["Host"];
            LoggedUser user = (LoggedUser)Session["User"];
            Property property = Property.retrieveProperty(propertyId);
            if (host != null && property.host.loginName == host.loginName)
            {
                FileUpload.Visible = true;
                btnUpload.Visible = true;
                AddPicLabel.Visible = true;
                DoBookingBtn.Visible = false;
                ContactHostBtn.Visible = false;
                checkAvailability.Visible = true;
            }
            else if (host != null)
            {
                DoBookingBtn.Visible = false;
                ContactHostBtn.Visible = false;
            }
            else if(user != null) {
                int visitsOfUser = Booking.getAllVisitsOfThisUserInProperty(user.loginName, propertyId);
                if (visitsOfUser >= 1)
                {
                    FileUpload.Visible = true;
                    btnUpload.Visible = true;
                    AddPicLabel.Visible = true;
                    DoBookingBtn.Visible = true;
                    ContactHostBtn.Visible = true;
                }
                else
                {
                    DoBookingBtn.Visible = true;
                    ContactHostBtn.Visible = true;
                }
            }
            else
            {
                DoBookingBtn.Visible = false;
                ContactHostBtn.Visible = false;
            }

            FetchImage(propertyId);
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
        int propertyId = (int)Session["propertyId"];
        property = Property.retrieveProperty(propertyId);
        Session["messageFor"] = property.host;
        Response.Redirect("DisplayMessages.aspx");

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
            if (Session["propertyId"] == null)
            {
                Response.Redirect("SearchResult.aspx");
            }
            else
            {
                int propertyId = (int)Session["propertyId"];
                Stream fs = FileUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                Host host = Session["Host"] != null ? (Host)Session["Host"] : null;
                User user = Session["User"] != null ? (User)Session["User"] : null;
                Image image = null;

                if (user != null)
                {
                    image = new Image(filename, contenttype, bytes, user.loginName, propertyId);
                }
                else
                {
                    image = new Image(filename, contenttype, bytes, host.loginName, propertyId);
                }

                if (image.saveImageInDb())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "File Uploaded Successfully";
                    Image1.Visible = false;
                    Images.Controls.Clear();
                    FetchImage(propertyId);
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "File format not recognised." + propertyId +
                      " Upload Image formats (jpg/png/gif)";
                }
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
        if (id != 0)
        {
            Image image = new Image();
            List<Image> images = image.loadImagesFromDbWithPropertyId(id);
            if (images.Count == 0)
            {
                Image1.Visible = id != 0;
                Image1.ImageUrl = "Content/Images/NoImageFound.png";
            }
            else
            {
                Images.Visible = true;
                foreach (Image i in images) {
                    System.Web.UI.WebControls.Image aux = new System.Web.UI.WebControls.Image();
                    aux.ImageUrl = "data:image/png;base64," + i.bytesInBase64;
                    Images.Controls.Add(aux);
                }

            }
        }
    }
}