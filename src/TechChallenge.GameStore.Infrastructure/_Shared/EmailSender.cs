using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TechChallenge.GameStore.Infrastructure._Shared;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task EnviarAsync(string destino, string assunto, string corpo)
    {
        var remetente = _configuration["Email:Remetente"];
        var host      = _configuration["Email:Smtp:Host"];
        var porta     = int.Parse(_configuration["Email:Smtp:Porta"]);
        var usuario   = _configuration["Email:Smtp:Usuario"];
        var senha     = _configuration["Email:Smtp:Senha"];

        using var smtpClient = new SmtpClient(host, porta);
        smtpClient.Credentials = new NetworkCredential(usuario, senha);
        smtpClient.EnableSsl = false;

        var mensagem = new MailMessage(remetente, destino, assunto, corpo);
        await smtpClient.SendMailAsync(mensagem);
    }
}

public interface IEmailSender
{
    Task EnviarAsync(string destino, string assunto, string corpo);
}