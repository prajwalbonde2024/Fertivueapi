using System.Net.Mail;

namespace EComApplication.Services
{
    public class SendmailService
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public SendmailService(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }

        public void SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("your-email@gmail.com"),
                    Subject = "Demo Request Confirmation - We'll Be in Touch Soon",
                    Body = GetEmailBody(), 
                    IsBodyHtml = true
                };

                mail.To.Add(Email); 
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("prajwal.bonde@vidaisolutions.com", "kpus nswg jaas jyht"), // Replace with actual credentials
                    EnableSsl = true
                };
                smtpServer.Send(mail);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }

        private string GetEmailBody()
        {
            return $@"
                <html>
                <head>
                    <style>
                        .email-signature {{
                            font-family: Arial, sans-serif;
                            color: #333;
                        }}
                        .signature-name {{
                            font-size: 16px;
                            font-weight: bold;
                        }}
                        .signature-title {{
                            font-size: 14px;
                            color: #777;
                        }}
                        .signature-email {{
                            font-size: 14px;
                            color: #1a73e8;
                            text-decoration: none;
                        }}
                        .signature-logo {{
                            max-width: 150px;
                            margin-top: 10px;
                        }}
                        .signature-container {{
                            display: flex;
                            flex-direction: row;
                            align-items: center;
                        }}
                        .signature-text {{
                            margin-left: 10px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='email-signature'>
                        <p>Dear {UserName},</p>
                        <p>Thank you for your interest in scheduling a demo with us! We’ve received your request, and one of our sales representatives will be reaching out to you shortly to confirm a suitable time for the demo and discuss your specific needs.</p>
                        <p>In the meantime, if you have any questions or would like more information, feel free to reply to this email or contact us at 7030554623 or prajwal.bonde@vidaisolution.com.</p>
                        <p>We look forward to connecting with you soon!</p>
                        
                        <div class='signature-container'>
                            <div>
                                <p class='signature-name'>Best Regards,</p>
                                <p class='signature-name'>Prajwal Bonde</p>
                                <p class='signature-title'>Software Developer</p>
                                <a class='signature-email' href='mailto:prajwal.bonde@vidaisolutions.com'>prajwal.bonde@vidaisolutions.com</a>
                            </div>
                            <!--<div>
                                <img class='signature-logo' src='http://localhost:5005/Logo/fertivuelogo-06.png' alt='VIDAI Logo'/>
                            </div>-->
                        </div>
                        <!--<p style='font-size: 12px; color: #777;'>VIDAI AI-Powered EMR <br> a Progenesis company</p>-->
                    </div>
                </body>
                </html>";
        }
    }
}
