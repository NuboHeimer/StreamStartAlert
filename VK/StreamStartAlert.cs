///----------------------------------------------------------------------------
///   Module:       Stream start annonce to VK
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      0.1.0
///----------------------------------------------------------------------------
///
using System;
using System.Net.Http;
using System.Collections.Generic;

public class CPHInline
{
    public bool Execute()
    {
        string owner_id = args["vkChat"].ToString();
        string token = args["vkToken"].ToString();
        string form_group = "1";
        string scope = "wall";
        string v = "5.199";
        string message = "";
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
        
        message = message + annonceText + "\n\nИгра —" + game + "\n\n" + translationTitle + "\n\n" + vkplLink + "\nЦели:\n  ● Средний онлайн — " + vkplOnilne + "\n\n" + twitchLink + "\nЦели:\n  ● Фолловеры — " + twitchFollowers.Replace("twitchFollowerCount", twitchFollowerCount) + "\n\n" + youTubeLink + "\nЦели:\n  ● Фолловеры — " + youTubeFollowers.Replace("youTubeFollowerCount", youTubeFollowerCount) + "\n\n";
        
        this.perform(owner_id, form_group, scope, message, token, v);
        return true;
    }

    private async void perform(string owner_id, string form_group, string scope, string message, string token, string v)
    {
        HttpClient client = new HttpClient();

        var content = new FormUrlEncodedContent(new[] 
        {
            new KeyValuePair<string, string>("owner_id", owner_id),
            new KeyValuePair<string, string>("form_group", form_group),
            new KeyValuePair<string, string>("message", message),
            new KeyValuePair<string, string>("access_token", token),
            new KeyValuePair<string, string>("scope", scope),
            new KeyValuePair<string, string>("v", v),
        });
    
        string url = "https://api.vk.com/method/wall.post?";

        //POST the object to the specified URI 
        var response = await client.PostAsync(url, content);
        var responseString = await response.Content.ReadAsStringAsync();
    }
}