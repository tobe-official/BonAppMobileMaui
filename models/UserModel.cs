namespace BonAppMobileMaui.models;

public class User(
    string username,
    string email,
    string password,
    List<int> favoredMeals,
    List<string> followingUsernames,
    List<string> followersUsernames,
    List<int> likedMeals,
    List<int> swipedMeals,
    TimeSpan preferredMealTime,
    bool isVegan,
    bool isVegetarian,
    bool isMeatEater,
    DateTime dateOfBirth,
    bool notificationEnabled)
{
    public string Username { get; set; } = username;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public List<int> FavoredMeals { get; set; } = favoredMeals;
    public List<string> FollowingUsernames { get; set; } = followingUsernames;
    public List<string> FollowersUsernames { get; set; } = followersUsernames;
    public List<int> LikedMeals { get; set; } = likedMeals;
    public List<int> SwipedMeals { get; set; } = swipedMeals;
    public TimeSpan PreferredMealTime { get; set; } = preferredMealTime; 
    public bool IsVegan { get; set; } = isVegan;
    public bool IsVegetarian { get; set; } = isVegetarian;
    public bool IsMeatEater { get; set; } = isMeatEater;
    public DateTime DateOfBirth { get; set; } = dateOfBirth;
    public bool NotificationEnabled { get; set; } = notificationEnabled;
}