using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Events.EventArguments;
using Tweetinvi.Core.Interfaces.Streaminvi;

namespace noerd.Lyttepost.Core.Services.NoerdBot
{
    public class NoerdBotService
    {

        private static bool IsAuthenticated { get; set; }
        private static IUserStream _userStream;


        // ---------------------------------------------------------------------------------

        public string StartStream()
        {
            Authenticate();
            
            //PostMessage("Hello world!");

            _userStream = Stream.CreateUserStream();

            _userStream.StreamStarted += (sender, args) =>
            {
                var tweet = Tweet.CreateTweet("Så er vi i gang :)");
                tweet.Publish();
            };
            _userStream.StreamStopped += (sender, args) =>
            {
                PostMessage("App offline " + DateTime.Now.ToUniversalTime());
            };

            _userStream.FollowedByUser += (sender, args) => { PostMessage("New follower!"); };
            _userStream.MessageReceived += (sender, args) => { PostMessage("Message received!"); };
            _userStream.MessageSent += (sender, args) => { PostMessage("Message sent!"); };
            _userStream.TweetCreatedByAnyone += (sender, args) => { PostMessage("TweetCreatedByAnyone");  };

            _userStream.StartStream();

            //_userStream.StopStream();

            return "Goodbye";

        }

        // ---------------------------------------------------------------------------------

        private  bool PostMessage(string text)
        {
            var tweet = Tweet.CreateTweet(text);
            return tweet.Publish();
            
        }

        // ---------------------------------------------------------------------------------

        private static void OnNewFollower(UserEventArgs userFollowedEventArgs)
        {
            var text = string.Format("Woohoo, I just got a new follower! Hello {0}!", userFollowedEventArgs.User.ScreenName);
            //PostMessage(text);
            _userStream.StopStream();
        }

        // ---------------------------------------------------------------------------------

        private static void OnTweetRecieved(MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            var text = string.Format("I just received a message from {0}!", message.SenderScreenName);

            //PostMessage(text);
            _userStream.StopStream();
        }

        // ---------------------------------------------------------------------------------

        private void Authenticate()
        {
            if (IsAuthenticated)
                return;

            var consumerKey = "ljs4Nmg50ZtzuCaia4MB1OInj";
            var consumerSecret = "Sg6tuHIkULw76uIW6uJW0q0t1OPuclhR41XY09XReI0zo21pJ4";
            var accessToken = "2827372065-ZFYOIDEIQjOMqHlxHGekAJDzjeg4fVxSW387y8X";
            var accessTokenSecret = "je3stVl5LhZvt6BZHF2TAily6L2LcTHuTvDOn49HTtsr2";

            //TwitterCredentials.SetCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");
            TwitterCredentials.SetCredentials(accessToken, accessTokenSecret, consumerKey, consumerSecret);
            //TwitterCredentials.SetCredentials(applicationCredentials.AuthorizationKey, applicationCredentials.AuthorizationSecret, applicationCredentials.ConsumerKey, applicationCredentials.ConsumerSecret);

            IsAuthenticated = true;
        }

    }
}
