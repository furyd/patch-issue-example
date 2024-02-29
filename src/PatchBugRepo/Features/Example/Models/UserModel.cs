using SystemTextJsonPatch;

namespace PatchBugRepo.Features.Example.Models
{
    public class UserModel
    {
        public string? FirstName { get; set; }
    }

    public record MessageModel<T>(Guid Id, T Model) where T : class;

    public record PatchMessageModel<T>(Guid Id, JsonPatchDocument<T> Model) : MessageModel<JsonPatchDocument<T>>(Id, Model) where T : class;
}
