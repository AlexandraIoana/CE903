using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayMessages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        LoggedUser user = (LoggedUser)Session["User"];
        Host host = (Host)Session["Host"];
        if (user != null)
        {
            host = (Host)Session["messageFor"];
        }
        else if (host != null)
        {
            user = (LoggedUser)Session["messageFor"];
        }
        else
        {
            Response.Redirect("ViewProperty.aspx");
        }
        ArrayList conversation = MessageSystem.retrieveConversation(user, host);
        user_name.Text = user.name;
        host_name.Text = host.name;
        foreach (ArrayList a in conversation)
        {
            if (a[1].Equals("user"))
            {
                Label lab = new Label();
                lab.Text = user.name + " : ";
                messages.Controls.Add(lab);
            }
            if (a[1].Equals("host"))
            {
                Label lab = new Label();
                lab.Text = host.name + " : ";
                messages.Controls.Add(lab);
            }

            messages.Controls.Add(new LiteralControl("<br />"));

            TextBox text = new TextBox();
            text.Text = (string)a[0] + ";";
            text.ReadOnly = true;
            messages.Controls.Add(text);

            messages.Controls.Add(new LiteralControl("<br />"));



        }

    }

    protected void send_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String initiator;
            
            LoggedUser user = LoggedUser.retrieveUser("johnWater");
            if (new_message.Text == null)
            {
                empty_message.Text = "Please input a message to be sent.";
            }
            else
            {
                //check whether it's a user or a host who is trying to send a message
                LoggedUser loggedUser = (LoggedUser)Session["User"];
                Host loggedHost = (Host)Session["Host"];
                if (loggedUser != null)
                {
                    initiator = "user";
                    loggedHost = (Host)Session["messageFor"];
                    MessageSystem.sendMessage(user, loggedHost, new_message.Text, initiator);
                    Response.Redirect("DisplayMessages.aspx");
                    empty_message.Text = "Message sent succesfully.";
                }
                else if (loggedHost != null)
                {
                    initiator = "host";
                    loggedUser = (LoggedUser)Session["messageFor"];
                    empty_message.Text = initiator;
                    MessageSystem.sendMessage(user, loggedHost, new_message.Text, initiator);
                    Response.Redirect("DisplayMessages.aspx");
                    empty_message.Text = "Message sent succesfully.";
                }

                
            }




        }



    }
}