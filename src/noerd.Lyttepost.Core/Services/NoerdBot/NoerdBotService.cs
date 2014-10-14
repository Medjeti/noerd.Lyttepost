using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Events;
using Tweetinvi.Core.Events.EventArguments;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Streaminvi;

namespace noerd.Lyttepost.Core.Services.NoerdBot
{
    public class NoerdBotService
    {

        private bool IsAuthenticated { get; set; }
        private IUserStream _userStream;
        private Thread _thread;

        // ---------------------------------------------------------------------------------

        public void StartStream()
        {
            Authenticate();

            SetupUserStream();

            //return "Goodbye";

        }

        // ---------------------------------------------------------------------------------

        private void SetupUserStream()
        {
            _userStream = Stream.CreateUserStream();

            _userStream.StreamStarted += (sender, args) =>
            {
                var timestamp = DateTime.Now.ToUniversalTime();
                PostMessage(string.Format("App online as of {0}. Ask away!", timestamp));
            };
            _userStream.StreamStopped += (sender, args) =>
            {
                var timestamp = DateTime.Now.ToUniversalTime();
                PostMessage(string.Format("App offline as of {0}. Bye-bye.", timestamp));
            };

            _userStream.FollowedByUser += (sender, args) => { OnNewFollower(args); };
            //_userStream.MessageReceived += (sender, args) => { PostMessage("Message received!"); };
            //_userStream.MessageSent += (sender, args) => { PostMessage("Message sent!"); };
            //_userStream.TweetCreatedByAnyone += (sender, args) => { OnTweetRecieved(args); };
            _userStream.TweetCreatedByAnyoneButMe += (sender, args) => { OnTweetRecieved(args); };
            //_userStream.TweetCreatedByFriend += (sender, args) => { PostMessage("TweetCreatedByFriend"); };

            _thread = new Thread(_userStream.StartStream);
            _thread.Start();

            //_userStream.StartStream();

            //_userStream.StopStream();
        }

        // ---------------------------------------------------------------------------------

        private bool PostMessage(string text)
        {
            return PostMessage(text, null);
        }

        private bool PostMessage(string text, ITweet origTweet)
        {
            if (origTweet != null)
            {
                origTweet.PublishReply(text);
                return true;
            }
            else
            {
                var tweet = Tweet.CreateTweet(text);
                return tweet.Publish();   
            }
        }

        // ---------------------------------------------------------------------------------

        private void OnNewFollower(UserEventArgs eventArgs)
        {
            var text = string.Format("Yay, a new follower! Hello @{0}, welcome to the party :)", eventArgs.User.ScreenName);
            PostMessage(text);
            //_userStream.StopStream();
        }
         
        // ---------------------------------------------------------------------------------

        private void OnTweetRecieved(TweetEventArgs eventArgs)
        {
            var tweet = eventArgs.Tweet;
            var creator = tweet.Creator;
            var text = "";

            if (tweet.Text.Contains('?'))
            {
                var answer = GetRandomAnswer();
                text = string.Format(
                    "Hello @{0}, thanks for your question! My answer is: {1}", 
                    creator.ScreenName,
                    answer);
            }
            else
            {
                text = string.Format(
                    "Hello @{0}, thanks for your message! Unfortunately I don't know how to answer that. Please rephrase in the form of a question.",
                    creator.ScreenName);
            }
            PostMessage(text, tweet);

            //_userStream.StopStream();
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

        // ---------------------------------------------------------------------------------

        private string GetRandomAnswer()
        {
            var answers = new []
            {
                "All signs point to yes!", 
                "Absolutely!",
                "I am leaning towards yes.",
                "I can't seem to decide...", 
                "Probably not...", 
                "Absolutely not!", 
                "42."
            };

            var random = new Random();
            var r = random.Next(answers.Count());

            return answers[r];
        }

    }
}
