///----------------------------------------------------------------------------
///   Module:       Stream start annonce to discord
///   Author:       NuboHeimer (https://vkplay.live/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///   Telegram:     t.me/nuboheimer
///   Version:      0.1.1
///----------------------------------------------------------------------------
///
using System;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

public class CPHInline
{
    public bool Execute()
    {
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
        string token = args["telegramToken"].ToString();
        string chat = args["telegramChat"].ToString();
        string preview = args["pathToPreview"].ToString() + "Preview.png";
        
        message = message + annonceText + "\n\n**Игра — " + game + "**\n\n_" + translationTitle + "_\n\n" + vkplLink + "\n```\nЦели:\n  ● Средний онлайн — " + vkplOnilne + "\n```\n\n" + twitchLink + "\n```\nЦели:\n  ● Фолловеры — " + twitchFollowers.Replace("twitchFollowerCount", twitchFollowerCount) + "\n```\n\n" + youTubeLink + "\n```\nЦели:\n  ● Фолловеры — " + youTubeFollowers.Replace("youTubeFollowerCount", youTubeFollowerCount) + "\n```\n\n";
        
        this.perform(message, token, chat, preview, vkplLink, twitchLink, youTubeLink);
        return true;
    }

    private async void perform(string message, string token, string chat, string filePath, string vkplLink, string twitchLink, string youTubeLink)
    {
        
        var fileName = "preview";
        
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chat.ToString()), "chat_id");
                form.Add(new StringContent(message.ToString()), "caption");
                form.Add(new StringContent("Markdown"), "parse_mode");
                var button = "{\"inline_keyboard\":[[{\"text\": \"VkPlay\", \"url\": \""+vkplLink+"\"}, {\"text\": \"Twitch\", \"url\": \""+twitchLink+"\"}], [{\"text\": \"YouTube\", \"url\": \""+youTubeLink+"\"}]]}";
                form.Add(new StringContent(button.ToString()), "reply_markup");

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "photo", fileName);

                    using (var client = new HttpClient())
                    {
                        string url = "https://api.telegram.org/bot"+token+"/sendPhoto";
                        await client.PostAsync(url, form);
                    }
                }
        

        }
    }
}