using System.Net;
using System.Net.Mail;
using Bank.RabbitMQConsumer.Models;

namespace Bank.RabbitMQConsumer.Service;

public static class MailService
{
    public static async Task SendAsync(UserTransactionDto userTransactionDto)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential("yzl3157test@gmail.com",
            "atlkbjteiruyhcww");
        
        MailMessage mail = new MailMessage("yzl3157test@gmail.com", userTransactionDto.User.Email);

        mail.Subject = "Bilgilendirme!!!";
        mail.Body = MessageBodyGenerete(userTransactionDto);

        try
        {
            await smtp.SendMailAsync(mail);
        }
        catch (Exception)
        {
            Console.WriteLine($"Mesaj gönderilemedi.");
        }
    }

    private static string MessageBodyGenerete(UserTransactionDto userTransactionDto)
    {
        return $"Sayın {userTransactionDto.User.FirstName.ToUpper()+ " " + userTransactionDto.User.LastName.ToUpper()} \n \n" +
               $"{userTransactionDto.Account.LastActivty.ToShortDateString()} tarihinde {userTransactionDto.Transaction.SenderAccontNo}'lu hesabınızdan {userTransactionDto.Transaction.RecipientAccoundNo}'lu hesaba {userTransactionDto.Transaction.Amount} para transferi gerçekleşmiştir. Güncel hesap bakiyeniz {userTransactionDto.Account.Balance} TL dir.";
    }
}

