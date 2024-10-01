namespace Pastebin.API.Contracts
{
    internal record ErrorResponse(
        int Status,
        string Message
        );
}
