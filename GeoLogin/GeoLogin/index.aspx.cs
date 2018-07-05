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
        string textbody = 

        "<center><h3 style='padding:15px; background-color:#5cb85c; color:#fff; width:50%;'>geo login</h3><table>" +
        "<tr ><td style='padding:5px; border-bottom:1px solid #eee; '> <b>sign type </b></td><td style='padding:5px; border-bottom:1px solid #eee; '> " + signType.SelectedValue + "</td></tr>" +
          "<tr><td style='padding:5px; border-bottom:1px solid #eee; '> <b>dsp name</b> </td><td style='padding:5px; border-bottom:1px solid #eee; '> " + dspName.Text + "</td></tr>" +
          "<tr><td style='padding:5px; border-bottom:1px solid #eee; '> <b>client name</b> </td><td style='padding:5px; border-bottom:1px solid #eee; '> " + clientName.Text + "</td></tr>" +
          "<tr><td style='padding:5px; border-bottom:1px solid #eee; '> <b>client address</b> </td><td style='padding:5px; border-bottom:1px solid #eee; '> " + currentLocation.Text + "</td></tr>" +
          "<tr><td style='padding:5px; border-bottom:1px solid #eee; '> <b>time</b></td><td style='padding:5px; border-bottom:1px solid #eee; '> " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "</td></tr>" +
          "<tr><td style='padding:5px;'> <b>date of service</b> </td><td style='padding:5px; '> " + DateTime.Now.ToString("m/d/yyyy") + "</td></tr>" +
          "</table></center>";

        //        MailMessage mail = new MailMessage();
        //        mail.To.Add(new MailAddress("farahoffice09@gmail.com"));
        //        mail.From = new MailAddress("shahbaz@teamcodeboy.com");
        //        mail.Subject = "Geo Sign In";
        //        mail.IsBodyHtml = true;
        //        mail.Body = textbody;

        //        SmtpClient client = new SmtpClient();
        //        client.Host = "relay-hosting.secureserver.net";
        //        client.Port = 25;
        //        client.EnableSsl = true;
        //        client.Credentials = new System.Net.NetworkCredential("shahbaz@teamcodeboy.com", "Shah@0092ss");
        //        try
        //        {
        //            client.Send(mail);
        //            string myScriptValue = " alert('Successfully Sent !Thank you.'); ";
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
        //            dspName.Text = "";
        //            clientName.Text = "";
        //            currentLocation.Text = "";
        //        }
        //        catch (Exception)
        //        {
        //            string myScriptValue1 = " alert('Error!!! Sorry .'); ";
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue1, true);
        //        }
        //    }
        //}


        MailMessage mail = new MailMessage();
mail.To.Add(new MailAddress("shahbaz.0092.ss@gmail.com"));
        mail.From = new MailAddress("shahbaz.0092.ss@gmail.com");
mail.Subject = "Geo Sign In";
        mail.IsBodyHtml = true;
        mail.Body = textbody;

        SmtpClient client = new SmtpClient();
client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.EnableSsl = true;
        client.Credentials = new System.Net.NetworkCredential("shahbaz.0092.ss@gmail.com", "Shahbaz@0092ss");
       // client.Credentials = new System.Net.NetworkCredential("farahoffice09@gmail.com", "Abcd@123");
        try
        {
            client.Send(mail);
            string myScriptValue = " alert('Successfully Sent !Thank you.'); ";
ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
dspName.Text = "";
clientName.Text = "";
currentLocation.Text = "";
}
        catch (Exception)
        {
string myScriptValue1 = " alert('Error!!! Sorry .'); ";
ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue1, true);
}
    }
}