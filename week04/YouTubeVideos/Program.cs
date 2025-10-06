using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to Cook Rice", "Chef Ben", 300);
        Video video2 = new Video("Python for Beginners", "CodeWithJeff", 600);
        Video video3 = new Video("Top 10 Travel Destinations", "GlobeTrotter", 480);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "This helped me cook perfect rice!"));
        video1.AddComment(new Comment("Bob", "Nice tutorial."));
        video1.AddComment(new Comment("Charlie", "Short and clear!"));

        // Add comments to video2
        video2.AddComment(new Comment("Diana", "Python looks fun!"));
        video2.AddComment(new Comment("Eric", "Great for beginners."));
        video2.AddComment(new Comment("Fiona", "Can you make one on OOP next?"));

        // Add comments to video3
        video3.AddComment(new Comment("George", "Adding these to my bucket list!"));
        video3.AddComment(new Comment("Hannah", "Great recommendations."));
        video3.AddComment(new Comment("Ian", "The music is amazing!"));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
