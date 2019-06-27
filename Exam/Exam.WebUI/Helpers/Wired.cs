using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.WebUI.Helpers
{
    public class Wired
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public static List<Wired> GetWireds()
        {
            List<Wired> wireds = new List<Wired>
            {
                new Wired{
                    ID =1,
                    title ="DISNEY'S NEW LION KING IS THE VR-FUELED FUTURE OF CINEMA",
                    content ="FOR THE 26 million people who watched Friends in the mid-’90s, Jon Favreau was Pete Becker. Not the star filmmaker who would make Elf a holiday classic; or who’d launch the Marvel juggernaut by directing Iron Man; or who’d update The Jungle Book for the CGI generation. Just Becker, a tech whiz who—before wooing Monica in a six-episode arc—had become a gazillionaire by creating a piece of business software called Moss 865. It was so named for a reason. Moss 1 exploded. Moss 2 would only schedule appointments for January. Becker, convinced his idea would change the world, pressed on. Today, it’s hard to describe Favreau’s latest project, the much-anticipated Lion King remake, without thinking of Pete Becker."
                },
                new Wired{
                    ID =2,
                    title ="PARTY TIME! 12 AMAZINGLY ADDICTIVE COUCH CO-OP GAMES",
                    content ="There comes a time in every gamer's life when they invite a friend or two (or three) over, and must reckon with the ultimate question: What to play? In the past few years, many games have begun only supporting online cooperative play, and sometimes it feels like local options are slim. Thankfully, that's not the case; the days of split-screen gaming are far from over. Plenty of great couch co-op games hit shelves each year. To prove it, we've rounded up some of the very best cooperative titles for the PlayStation 4, Xbox One, Windows PC, and Nintendo Switch."
                },
                new Wired{
                    ID =3,
                    title ="ALL OF THINKGEEK IS ON SALE (AND 14 MORE WEEKEND DEALS)",
                    content ="IF YOU LIVE north of the equator, you just lived through the summer solstice on June 21. But don't worry—even if you didn't get to see nearly 24 straight daylight hours in Alaska, or dance the day away at Stonehenge, we still have plenty of reasons for you to celebrate. This weekend, we searched the web to find deals on everything from MacBooks to beach chairs and more. Note: When you buy something using the retail links in our stories, we may earn a small affiliate commission. Read more about how this works."
                },
                new Wired{
                    ID =4,
                    title ="ANGRY NERD: KICKSTARTER HAS BECOME NO FUN AT ALL",
                    content ="Socialism schmocialism—I've never minded redistributing a bit of wealth to help a creator realize their dreams (or cover a few medical bills). I'm Angry Nerd, not Scroogey Nerd. But backing a project on Kickstarter these days? RIP my inbox: Hey, we just added a new stretch goal! Hey, if you upgrade your pledge, we'll be so close to unlocking another pledge goal! Hey, we added a one-of-a-kind macaroni art pledge tier for just $100 more! How much is the stretch goal for cutting the crap and finishing the damn job? "
                },
                new Wired{
                    ID =5,
                    title ="PLANET-SAVING ROBOTS? ROBERT DOWNEY JR. IS ON TO SOMETHING",
                    content ="Earlier this month, Robert Downey Jr. announced that he was forming a new organization, the Footprint Coalition, to apply technology to 'clean up' the planet.  The coalition's website is still scant on details, just a teaser for news to come. But regardless of how Downey Jr.'s grand plan shapes up, the idea is notable for its premise: New tools can and should be developed to understand and protect the natural world. I, for one, welcome these new conservation technologists."
                }
            };
            return wireds;
        }
    }
}
