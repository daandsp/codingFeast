using Application.Actions.Authentication.Queries.Manage2fa;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Text.Encodings.Web;

namespace Application.Actions.Authentication.Queries.Enable2fa;

public record GetEnable2FaDataQuery : IRequest<GetEnable2FaDataVm>
{
    public string UserId { get; set; }
}

public class Enable2FaQueryHandler : IRequestHandler<GetEnable2FaDataQuery, GetEnable2FaDataVm>
{
    private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly UrlEncoder _urlEncoder;

    public Enable2FaQueryHandler(
        UserManager<ApplicationUser> userManager,
        UrlEncoder urlEncoder)
    {
        _userManager = userManager;
        _urlEncoder = urlEncoder;
    }

    public async Task<GetEnable2FaDataVm> Handle(GetEnable2FaDataQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user == null)
        {
            return null;
        }

        return await LoadSharedKeyAndQrCodeUriAsync(user);
    }

    private async Task<GetEnable2FaDataVm> LoadSharedKeyAndQrCodeUriAsync(ApplicationUser user)
    {
        // Load the authenticator key & QR code URI to display on the form
        var unformattedKey = await _userManager.GetAuthenticatorKeyAsync(user);
        if (string.IsNullOrEmpty(unformattedKey))
        {
            await _userManager.ResetAuthenticatorKeyAsync(user);
            unformattedKey = await _userManager.GetAuthenticatorKeyAsync(user);
        }

        var email = await _userManager.GetEmailAsync(user);

        var response = new GetEnable2FaDataVm()
        {
            SharedKey = FormatKey(unformattedKey),
            AuthenticatorUri = GenerateQrCodeUri(email, unformattedKey)
        };

        return response;
    }

    private string FormatKey(string unformattedKey)
    {
        var result = new StringBuilder();
        int currentPosition = 0;
        while (currentPosition + 4 < unformattedKey.Length)
        {
            result.Append(unformattedKey.Substring(currentPosition, 4)).Append(" ");
            currentPosition += 4;
        }
        if (currentPosition < unformattedKey.Length)
        {
            result.Append(unformattedKey.Substring(currentPosition));
        }

        return result.ToString().ToLowerInvariant();
    }

    private string GenerateQrCodeUri(string email, string unformattedKey)
    {
        return string.Format(
        AuthenticatorUriFormat,
        _urlEncoder.Encode("GreenShift"),
            _urlEncoder.Encode(email),
            unformattedKey);
    }
}