using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BSATroop829.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;
    private IConfiguration _configuration;
    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<EmailSender> logger, IConfiguration configuration)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
        _configuration = configuration;
    }

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.SendGridKey))
        {
            await Execute(_configuration["SendGridKey"], subject, message, toEmail);
        }
        await Execute(Options.SendGridKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message, string toEmail)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("ScoutTroop829Webmaster@gmail.com", "829 WebApp Request"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
            
        };
        msg.AddTo(new EmailAddress(toEmail));

        var EmailVerificationid = "d-eb1729fe67104227bc13aa7e60b33084";

        // Disable click tracking.
        // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        msg.SetClickTracking(false, false);
        var response = await client.RequestAsync(
            method: SendGridClient.Method.GET,
            urlPath: $"designs/{EmailVerificationid}"
        );
        _logger.LogInformation(response.IsSuccessStatusCode
                               ? $"Email to {toEmail} queued successfully!"
                               : $"Failure Email to {toEmail}");
    }
}
