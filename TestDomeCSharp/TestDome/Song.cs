using System;
using System.Collections.Generic;

public class Song
{
    private string name;
    public Song NextSong { get; set; }

    public Song(string name)
    {
        this.name = name;
    }

    public bool IsRepeatingPlaylist()
    {
        var songs = new HashSet<string>();
        var currentSong = this;

        while (true)
        {
            if (currentSong == null)
            {
                return false;
            }
            if (songs.Contains(currentSong.name))
            {
                return true;
            }
            songs.Add(currentSong.name);
            currentSong = currentSong.NextSong;
        }
    }

    public static void TestSound(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");
        Song third = new Song("3");
        Song fourth = new Song("4");
        Song fifth = new Song("5");

        first.NextSong = second;
        second.NextSong = third;
        third.NextSong = fourth;
        fourth.NextSong = fifth;
        fifth.NextSong = first;

        Console.WriteLine(first.IsRepeatingPlaylist());
    }
}
