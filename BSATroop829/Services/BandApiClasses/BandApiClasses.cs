namespace BSATroop829.Services.BandApiClasses
{
    public class Author
    {
        public string name { get; set; }
        public string profile_image_url { get; set; }
        public string description { get; set; }
        public string role { get; set; }
        public string member_type { get; set; }
        public bool member_certified { get; set; }
        public bool me { get; set; }
        public bool is_muted { get; set; }
        public object created_at { get; set; }
        public string user_key { get; set; }
    }

    public class Item
    {
        public Author author { get; set; }
        public string post_key { get; set; }
        public string content { get; set; }
        public int comment_count { get; set; }
        public long created_at { get; set; }
        public List<Photo> photos { get; set; }
        public int emotion_count { get; set; }
        public List<LatestComment> latest_comments { get; set; }
        public string band_key { get; set; }
    }

    public class LatestComment
    {
        public string body { get; set; }
        public object created_at { get; set; }
        public Author author { get; set; }
    }

    public class NextParams
    {
        public string access_token { get; set; }
        public string band_key { get; set; }
        public string limit { get; set; }
        public string after { get; set; }
        public string local { get; set; }
    }

    public class Paging
    {
        public object previous_params { get; set; }
        public NextParams next_params { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public int width { get; set; }
        public object created_at { get; set; }
        public int comment_count { get; set; }
        public string url { get; set; }
        public int emotion_count { get; set; }
        public string photo_key { get; set; }
        public Author author { get; set; }
        public bool is_video_thumbnail { get; set; }
        public object photo_album_key { get; set; }
    }

    public class ResultData
    {
        public List<Item> items { get; set; }
        public Paging paging { get; set; }
    }

    public class Root
    {
        public int result_code { get; set; }
        public ResultData result_data { get; set; }
    }
}
