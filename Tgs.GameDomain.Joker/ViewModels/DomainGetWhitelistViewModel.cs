using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tgs.GameDomain.Joker.ViewModels;

public record DomainGetWhitelistViewModel
{
	[Required]
	[DefaultValue("https://w.api788.net/")]
	public Uri ApiUrl { get; init; } = default!;
	[Required]
	[DefaultValue("THDT")]
	public string AppId { get; init; } = default!;
	[Required]
	[DefaultValue("s5gawreoto5e1")]
	public string SecretKey { get; init; } = default!;
}
