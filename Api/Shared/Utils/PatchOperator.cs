using System.Text.Json;
using Api.Infrastructure.Entities;

namespace Api.Shared.Utils;

public static class PatchOperator
{
    public static void Card(CardEntity targetCard, string path, JsonElement value)
    {
        switch (path.ToLower())
        {
            case "/collectionid":
                targetCard.CollectionId = value.GetString();
                break;
            case "/ownerid":
                targetCard.OwnerId = value.GetString();
                break;
            case "/customdeckid":
                targetCard.CustomDeckId = value.GetString();
                break;
            case "/name":
                targetCard.Name = value.GetString();
                break;
            case "/description":
                targetCard.Description = value.GetString();
                break;
            case "/number":
                targetCard.Number = value.GetInt32();
                break;
            case "/manacost":
                targetCard.ManaCost = value.GetString();
                break;
            case "/label":
                targetCard.Label = value.GetString();
                break;
            case "/code":
                targetCard.Code = value.GetString();
                break;
            case "/foil":
                targetCard.Foil = value.GetBoolean();
                break;
            default:
                throw new InvalidOperationException($"Invalid Path: {path}");
        }
    }
}
