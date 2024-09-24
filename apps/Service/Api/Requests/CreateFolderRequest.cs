using System.ComponentModel.DataAnnotations;

using Shared.Validators.Attributes;

namespace Api.Requests
{
    public class CreateFolderRequest
    {
        [Required(ErrorMessage = "The name is required")]
        [StringLength(200, ErrorMessage = "Maximum 200 characters")]
        public required string Name { get; set; }

        [IsUuid]
        public string? FolderId { get; set; }
    }
}