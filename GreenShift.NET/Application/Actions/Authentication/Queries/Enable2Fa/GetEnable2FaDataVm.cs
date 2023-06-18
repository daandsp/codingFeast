namespace Application.Actions.Authentication.Queries.Enable2fa;

public class GetEnable2FaDataVm
{
    public string SharedKey { get; set; }
    public string AuthenticatorUri { get; set; }
}
