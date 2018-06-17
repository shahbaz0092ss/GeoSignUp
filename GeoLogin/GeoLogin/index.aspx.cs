using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitForm_Click(object sender, EventArgs e)
    {
        MailMessage mail = new MailMessage();
        mail.To.Add(new MailAddress("shahbaz.0092.ss@gmail.com"));
        mail.From = new MailAddress("shahbaz.0092.ss@gmail.com");
        mail.Subject = "Geo Sign In";
        mail.Body = name.Text + " has logged at "+currentLocation.Text +" .";

        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential("shahbaz.0092.ss@gmail.com", "****@****");
        try
        {
            client.Send(mail);
            string myScriptValue = "function callMe() {alert('Successful!'); }";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
        }
        catch (Exception)
        {

        }
    }
}