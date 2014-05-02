using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using com.strava.api.Activities;
using com.strava.api.Api;
using com.strava.api.Athletes;
using com.strava.api.Authentication;
using com.strava.api.Client;
using com.strava.api.Clubs;
using com.strava.api.Common;
using com.strava.api.Gear;
using com.strava.api.Http;
using com.strava.api.Segments;
using com.strava.api.Streams;
using com.strava.api.Utilities;
using WebRequest = com.strava.api.Http.WebRequest;

namespace StravaTestClient
{
    /// <summary>
    /// You can use this program to learn how to use the Strava.NET framework.
    /// If you have any questions or you have found an error please send an email to
    ///     strava@sascha-simon.com
    /// </summary>
    public class Program
    {
        public static void Main(String[] args)
        {
            Test();
            Console.ReadLine();
        }

        public async static void Test()
        {
            Console.WriteLine("Framework: {0}", Framework.Version);

            // Please use your own, valid token!
            const String token = "";

            // Use either the static authentication method or use the WebAuthentication method.
            StaticAuthentication auth = new StaticAuthentication(token);

            //WebAuthentication auth = new WebAuthentication();
            //auth.AuthCodeReceived += delegate(object sender, AuthCodeReceivedEventArgs args) { Debug.WriteLine("Auth Code: " + args.AuthCode); };
            //auth.AccessTokenReceived += delegate(object sender, TokenReceivedEventArgs args) { Debug.WriteLine("Access Token: " + args.Token); };
            //auth.GetTokenAsync("<Client id>", "<Client Secret>", Scope.Full);

            // You can either use the StravaClient or 'single' clients like the ActivityClient.
            // The StravaClient offers predefined clients.
            StravaClient client = new StravaClient(auth);

            AthleteSummary a = await client.Athletes.GetAthleteAsync();
            Console.WriteLine("{0} {1}", a.FirstName, a.LastName);

            #region Activities

            //var activities = client.Activities.GetActivities(new DateTime(2014, 1, 1), DateTime.Now);
            //var activitiesAsync = await client.Activities.GetActivitiesAsync(new DateTime(2014, 1, 1), DateTime.Now);

            //foreach (var item in activities)
            //{
            //    Console.WriteLine(DateConverter.ConvertIsoTimeToDateTime(item.StartDateLocal));
            //}

            //Console.WriteLine("Sync: " + activities.Count);
            //Console.WriteLine("Async: " + activitiesAsync.Count);

            #endregion

            #region Athlete

            //Athlete current = await client.Athletes.GetAthleteAsync();
            //Console.WriteLine(current);

            //List<AthleteSummary> friends = await client.Athletes.GetFriendsAsync();
            //Console.WriteLine(friends.Count);

            //List<AthleteSummary> bothFollowing = await client.Athletes.GetBothFollowingAsync("528819");
            //Console.WriteLine(bothFollowing.Count);

            //List<SegmentEffort> records = await client.Segments.GetRecordsAsync("528819");

            //foreach (SegmentEffort effort in records)
            //{
            //    Console.WriteLine(effort.Name);
            //}

            //List<SegmentSummary> starred = await client.Segments.GetStarredSegmentsAsync();
            //Console.WriteLine(starred.Count);

            #region Update Athlete Weight

            //Athlete a = client.GetAthlete();
            //Console.WriteLine(a.FirstName + " " + a.LastName);

            //Athlete updated = client.UpdateAthlete(AthleteParameter.Weight, "60.0");
            //Console.WriteLine(updated.Email);

            #endregion

            #endregion

            #region Map Decoder

            //Activity mapActivity = await client.Activities.GetActivityAsync("109557593", false);
            //List<Coordinate> coords = PolylineDecoder.Decode(mapActivity.Map.Polyline);

            //foreach (var coordinate in coords)
            //{
            //    Console.WriteLine(coordinate);
            //}

            #endregion

            #region Leaderboard

            // Get the leaderboard of a segment.
            //Leaderboard leaderboard = client.Segments.GetFullSegmentLeaderboard("1300798");

            //foreach (LeaderboardEntry entry in leaderboard.Entries)
            //{
            //    Console.WriteLine(entry.ToString());
            //}

            #endregion

            #region Comments

            //List<Comment> comments = await client.Activities.GetCommentsAsync("112861810");

            //foreach (var comment in comments)
            //{
            //    Console.WriteLine(comment.Text);
            //    Console.WriteLine();
            //}

            #endregion

            #region Kudos

            //List<Athlete> kudoAthletes = await client.Activities.GetKudosAsync("112818941");

            //foreach (var kudos in kudoAthletes)
            //{
            //    Console.WriteLine(kudos.FirstName);
            //}

            #endregion

            #region Club

            //Athlete clubAthlete = await client.Athletes.GetAthleteAsync();

            //foreach (Club club in clubAthlete.Clubs)
            //{
            //    Console.WriteLine(club.Id);
            //}

            //Club c = await client.Clubs.GetClubAsync("949");
            //Console.WriteLine("Club: {0}", c.Name);

            //Image image = await ImageLoader.LoadImage(new Uri(c.Profile));
            //Form form = new Form();
            //form.Controls.Add(new PictureBox() { Dock = DockStyle.Fill, Image = image, SizeMode = PictureBoxSizeMode.CenterImage });
            //form.ShowDialog();

            //// Gets all the clubs of the currently authenticated user.
            //Console.WriteLine("Clubs:");
            //List<ClubSummary> clubs = await client.Clubs.GetClubsAsync();

            //foreach (var club in clubs)
            //{
            //    Console.WriteLine(club.Name);
            //}

            //// Only returns a result, if the athlete is a member in the club.
            //List<AthleteSummary> athletes = await client.Clubs.GetClubMembersAsync("949");
            //foreach (AthleteSummary athlete in athletes)
            //{
            //    Console.WriteLine(athlete.FirstName + " " + athlete.LastName);
            //}

            #endregion

            #region ActivityZones

            //List<ActivityZone> zones = client.Activities.GetActivityZones("114701243");

            //foreach (var item in zones.First().Buckets)
            //{
            //    Console.WriteLine(item.Maximum + " " + item.Minimum + " " + item.Time);
            //}

            #endregion

            #region Club Activities

            //List<ActivitySummary> items = client.Clubs.GetLatestClubActivities("949", 1, 5);

            //foreach (var activity in items)
            //{
            //    Console.WriteLine(activity.Name);
            //}

            //Console.WriteLine();

            //items = client.Clubs.GetLatestClubActivities("949", 2, 5);

            //foreach (var activity in items)
            //{
            //    Console.WriteLine(activity.Name);
            //}

            #endregion

            #region Latest activities of your friends

            //List<ActivitySummary> activities = await client.Activities.GetFriendsActivitiesAsync(10);

            //foreach (var item in activities)
            //{
            //    Console.WriteLine(item.Name);
            //}

            #endregion

            #region ActivityReceived Event-Test

            //client.Activities.ActivityReceived += delegate(object sender, ActivityReceivedEventArgs args) { Console.WriteLine(args.Activity.Name); };
            //await client.Activities.GetAllActivitiesAsync();

            #endregion

            #region Gear

            //Athlete athleteGear = client.Athletes.GetAthlete();

            //foreach (var bike in athleteGear.Bikes)
            //{
            //    Bike gear = await client.Gear.GetGearAsync(bike.Id);
            //    Console.WriteLine(gear.Name);
            //}

            //foreach (Shoes shoes in athleteGear.Shoes)
            //{
            //    Bike gear = await client.Gear.GetGearAsync(shoes.Id);
            //    Console.WriteLine(gear.Name);
            //}

            #endregion

            #region Streams

            //List<ActivityStream> streams = client.Streams.GetActivityStream("117700501", StreamType.LatLng | StreamType.Heartrate);
            //foreach (var stream in streams)
            //{
            //    Console.WriteLine(stream.StreamType);
            //    Console.WriteLine(stream.OriginalSize);
            //    Console.WriteLine(stream.Data.Count);
            //}


            //List<SegmentStream> segmentStreams = client.Streams.GetSegmentStream("6295188", SegmentStreamType.LatLng | SegmentStreamType.Distance, StreamResolution.All);
            //foreach (var stream in segmentStreams)
            //{
            //    Console.WriteLine(stream.StreamType);
            //    Console.WriteLine(stream.OriginalSize);
            //}

            //List<ActivitySummary> ac = client.Activities.GetActivitiesAfter(new DateTime(2014, 1, 1));
            //Console.WriteLine(ac.Count);

            #endregion

            #region Update Activity

            //Activity a = await client.Activities.UpdateActivityTypeAsync("<activity id>", ActivityType.Ride);
            //Console.WriteLine(a.Type);

            //Activity a = await client.Activities.UpdateActivityAsync("<activity id>", ActivityParameter.Name, "Kurze Testfahrt nach Schaltzug- und Kettenwechsel");
            //Console.WriteLine(a.Name);

            #endregion

            #region Weekly Progress

            //WeeklyProgress p = client.Activities.GetWeeklyProgress();

            //Console.WriteLine(p.TotalTime);
            //Console.WriteLine(p.RideDistance / 1000F);
            //Console.WriteLine(p.ActivityCount);

            #endregion

            #region Summary

            //var activities = client.Activities.GetSummary(new DateTime(2014, 1, 1), DateTime.Now);
            //var activities = client.Activities.GetSummaryLastYear();
            //var activities = client.Activities.GetSummaryThisYear();

            //Console.WriteLine("Activities: " + activities.ActivityCount);
            //Console.WriteLine("Rides: " + activities.Rides.Count);
            //Console.WriteLine("Ride Distance: " + activities.RideDistance / 1000D);

            #endregion

            #region Time Filter

            //Leaderboard l = await client.Segments.GetSegmentLeaderboardAsync("6861720", TimeFilter.ThisYear);
            //foreach (var s in l.Entries)
            //{
            //    Console.WriteLine(s.AthleteName);
            //}

            #endregion

            #region Segment-Explorer
            
            //ExplorerResult result = await client.Segments.ExploreSegmentsAsync(
            //    new Coordinate(37.821362, -122.505373),
            //    new Coordinate(37.842038, -122.465977),
            //    0,
            //    5);

            //foreach (ExplorerSegment s in result.Results)
            //{
            //    Console.WriteLine(s.Name);
            //}

            #endregion

            #region Segment Efforts

            //List<SegmentEffort> efforts = await client.Efforts.GetSegmentEffortsByTimeAsync("6386278", new DateTime(2014, 1, 1), new DateTime(2014, 4, 10));
            //List<SegmentEffort> efforts = await client.Efforts.GetSegmentEffortsByAthleteAsync("6386278", "1985994");
            //List<SegmentEffort> efforts = await client.Efforts.GetSegmentEffortsAsync("6386278", "1985994", new DateTime(2014, 4, 8), new DateTime(2014, 4, 10));
            //List<SegmentEffort> efforts = await client.Efforts.GetSegmentEffortsAsync("6386278");
            
            //foreach (SegmentEffort effort in efforts)
            //{
            //    Console.WriteLine(effort.Athlete.Id);
            //    Console.WriteLine(" " + effort.MovingTime / 60 + "m" + effort.MovingTime % 60 + "s");
            //}


            #endregion

            #region MapLoader

            //Activity a = await client.Activities.GetActivityAsync("129042840", false);
            //Debug.WriteLine(a.Map.SummaryPolyline);

            //System.Drawing.Image image = await GoogleImageLoader.LoadActivityPreviewAsync(a.Map.SummaryPolyline, new Dimension(150, 150), MapType.Terrain);
            //Form form = new Form();
            //form.Size = new Size(300, 300);

            //PictureBox p = new PictureBox();
            //p.Dock = DockStyle.Fill;
            //p.Image = image;
            //form.Controls.Add(p);

            //form.ShowDialog();

            #endregion

            #region Photos

            ////List<Photo> photos = await client.Activities.GetPhotosAsync("133317643");
            ////Debug.WriteLine("Photos: " + photos.Count);

            //List<Photo> photos = await client.Activities.GetLatestPhotosAsync(new DateTime(2014, 1, 1));
            //Debug.WriteLine("Photos: " + photos.Count);

            #endregion

            #region Laps

            //List<ActivityLap> laps = await client.Activities.GetActivityLapsAsync("135450490");

            //foreach (var lap in laps)
            //{
            //    Console.WriteLine((lap.Distance / 1000F).ToString("F"));
            //}

            #endregion
        }

        // convert datetime to unix epoch seconds
        public static long ToUnixTime(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }
    }
}
