namespace TicmansoV2.Shared
{
    public class ServiceResponses
    {
        public record class GeneralResponse(bool Flag, string Message);
        public record class LoginResponse(bool Flag, string Token, string Message);
        public record class ChangePasswordResponse(bool Flag, string Message);

    }
}
