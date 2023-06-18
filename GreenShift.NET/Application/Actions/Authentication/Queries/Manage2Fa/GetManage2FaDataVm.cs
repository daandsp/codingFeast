namespace Application.Actions.Authentication.Queries.Manage2fa;

public class GetManage2FaDataVm
{
    public bool HasAuthenticator { get; set; }
    public int RecoveryCodesLeft { get; set; }
    public bool Is2faEnabled { get; set; }
    public bool IsMachineRemembered { get; set; }
}
