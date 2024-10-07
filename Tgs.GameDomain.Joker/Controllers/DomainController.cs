using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tgs.GameInterface.Joker.Client;

namespace Tgs.GameDomain.Joker.Controllers;
[Route("[controller]")]
[ApiController]
public class DomainController(
	IGameInterfaceJokerClient client) : ControllerBase
{
	/// <summary>
	/// Domains the get whitelist.
	/// </summary>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///				"apiUrl": "https://w.api788.net/",
	///				"appId": "THDT",
	///				"secretKey": "s5gawreoto5e1"
	///         }
	/// </remarks>

	[HttpGet]
	public async ValueTask<JsonNode> DomainGetWhitelist(
		[FromQuery] ViewModels.DomainGetWhitelistViewModel source)
	{
		var reply = await client.DomainGetWhitelistAsync(
			apiUrl: source.ApiUrl,
			appId: source.AppId,
			secretKey: source.SecretKey)
			.ConfigureAwait(false);

		return JsonNode.Parse(reply.Resp)!;
	}

	/// <summary>
	/// Domains the register whitelist.
	/// </summary>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///				"apiUrl": "https://w.api788.net/",
	///				"appId": "THDT",
	///				"secretKey": "s5gawreoto5e1",
	///				"domains": [
	///					"dev-t1.rpgp.cc",
	///					"stg-t1.rpgp.cc"
	///				]
	///         }
	/// </remarks>

	[HttpPost]
	public async ValueTask<JsonNode> DomainRegisterWhitelist(
		[FromBody] ViewModels.DomainRegisterWhitelistViewModel source)
	{
		var reply = await client.DomainRegisterWhitelistAsync(
			apiUrl: source.ApiUrl,
			appId: source.AppId,
			secretKey: source.SecretKey,
			domains: source.Domains)
			.ConfigureAwait(false);

		return JsonNode.Parse(reply.Resp)!;
	}

	/// <summary>
	/// Domains the un register whitelist.
	/// </summary>
	/// <param name="source">The source.</param>
	/// <returns></returns>
	/// <remarks>
	/// <b>Example</b><br />
	///
	///     Post
	///
	///         {
	///				"apiUrl": "https://w.api788.net/",
	///				"appId": "THDT",
	///				"secretKey": "s5gawreoto5e1",
	///				"domains": [
	///					"dev-t1.rpgp.cc",
	///					"stg-t1.rpgp.cc"
	///				]
	///         }
	/// </remarks>

	[HttpPut]
	public async ValueTask<JsonNode> DomainUnRegisterWhitelist(
		[FromBody] ViewModels.DomainUnRegisterWhitelistViewModel source)
	{
		var reply = await client.DomainUnRegisterWhitelistAsync(
			apiUrl: source.ApiUrl,
			appId: source.AppId,
			secretKey: source.SecretKey,
			domains: source.Domains)
			.ConfigureAwait(false);

		return JsonNode.Parse(reply.Resp)!;
	}
}
