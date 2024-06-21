///----------------------------------------------------------------------------
///   Module:       Stream start annonce to discord
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      2.0.0
///----------------------------------------------------------------------------
using System;

public class CPHInline
{
    public bool Execute()
    {
        string message = "";
        string roleForPing = args["roleForPing"].ToString();
        string pathToAlertText = args["pathToAlertText"].ToString();
        string twitchFollowerCount = args["followerCount"].ToString();
        string youTubeFollowerCount = args["youTubeFollowerCount"].ToString();
        string annonceText = args["annonceText"].ToString();
        string game = args["game"].ToString();
        string translationTitle = args["translationTitle"].ToString();
        string vkplLink = args["vkplLink"].ToString();
        string vkplOnilne = args  ["vkplOnilne"].ToString();
        string twitchLink = args["twitchLink"].ToString();
        string twitchFollowers = args["twitchFollowers"].ToString();
        string youTubeLink = args["youTubeLink"].ToString();
        string youTubeFollowers = args["youTubeFollowers"].ToString();

        message = message + roleForPing + "\n\n" + annonceText + "\n\n**Игра — " + game + "**\n\n_" + translationTitle + "_\n\n" + vkplLink + "\n```\nЦели:\n  ● Средний онлайн — " + vkplOnilne + "\n```\n\n" + twitchLink + "\n```\nЦели:\n  ● Фолловеры — " + twitchFollowers.Replace("twitchFollowerCount", twitchFollowerCount) + "\n```\n\n" + youTubeLink + "\n```\nЦели:\n  ● Фолловеры — " + youTubeFollowers.Replace("youTubeFollowerCount", youTubeFollowerCount) + "\n```\n\n";
        CPH.SetArgument("message", message);
        return true;
    }
}