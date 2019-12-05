using AndrewL_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace AndrewL_Blog.Helpers
{
    public class EmailHelper
    {

        private static string ConfiguredEmail = WebConfigurationManager.AppSettings["emailfrom"];
        public static async Task ComposeEmailAsync(EmailModel email)
        {
            try 
            {
                var senderEmail = $"{email.FromEmail}<{ConfiguredEmail}>"; //configuring the sender email using string interpilation
                var mailMsg = new MailMessage(senderEmail, ConfiguredEmail)
                {
                    Subject = email.Subject, // creating the mail massege.  it is fashioned after the default email
                    Body = $"<strong>{email.FromName}has sent you the following message</strong><hr/>{email.Body}", //entered by user
                    IsBodyHtml = true
                };
                var svc = new PersonalEmail(); //call the personal email a
                await svc.SendAsync(mailMsg); //fire off message
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                await Task.FromResult(0);

            }
        }

        public static async Task ComposeEmailAsync(RegisterViewModel model, string callbackUrl) 
            //cpmposing an email with a more specific purpose.  confirming your account
        {
            try 
            { 
            var senderEmail = $"Blog Admin<{ConfiguredEmail}>";  //sender email which is now coming from blog admin
            var mailMsg = new MailMessage(senderEmail, model.Email)
            {
                Subject = "Confirm you account",
                Body = $"Please confirm your account by clicking <a href=\"{callbackUrl}\">here</a>",
                IsBodyHtml = true
            };
                var svc = new PersonalEmail();
                await svc.SendAsync(mailMsg);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                await Task.FromResult(0);
            }

        }

        public static async Task ComposeEmailAsync(ForgotPasswordViewModel model, string callbackUrl) 
        {
            try 
            {

                var senderEmail = $"Blog Admin<{ConfiguredEmail}>";  //sender email which is now coming from blog admin
                var mailMsg = new MailMessage(senderEmail, model.Email)
                {
                    Subject = "Confirm you account",
                    Body = $"Please reset your account by clicking <a href=\"{callbackUrl}\">here</a>",
                    IsBodyHtml = true
                };
                var svc = new PersonalEmail();
                await svc.SendAsync(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Task.FromResult(0);
            }
        }
    }
}